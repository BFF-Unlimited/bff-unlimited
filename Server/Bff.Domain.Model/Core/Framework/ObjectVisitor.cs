﻿using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.Serialization;

namespace Bff.Domain.Model.Core.Framework
{

    public class ObjectVisitor
    {
        private const int CACHE_DURATION_IN_MINUTES = 15;
        private const int PRUNE_INTERVAL_IN_MINUTES = 30;
        private static readonly ConcurrentDictionary<Type, PropertyInfoCacheItem> Cache = new ConcurrentDictionary<Type, PropertyInfoCacheItem>();
        private static DateTime nextPrune = DateTime.Now.AddMinutes(PRUNE_INTERVAL_IN_MINUTES);

        public void VisitProperties(object o, Action<PropertyInfo, object> action)
        {
            this.Visit(null, o, new ObjectIDGenerator(), action);

            PruneCache();
        }

        private static void PruneCache()
        {
            if (DateTime.Now < nextPrune)
                return;

            nextPrune = DateTime.Now.AddMinutes(PRUNE_INTERVAL_IN_MINUTES);

            var keys = Cache.Values.Where(k => k.LastAccessed.AddMinutes(CACHE_DURATION_IN_MINUTES) < DateTime.Now).Select(k => k.Type).ToList();

            foreach (var key in keys)
                Cache.TryRemove(key, out _);
        }

        private void Visit(PropertyInfo propertyInfo, object o, ObjectIDGenerator idGenerator, Action<PropertyInfo, object> action)
        {
            idGenerator.GetId(o, out var firstTime);
            if (!firstTime)
                return;

            var t = o.GetType();

            if (IsEnumerable(t))
            {
                this.ProcessEnumerable(propertyInfo, o, idGenerator, action);
            }
            else
            {
                if (t.IsSystemType())
                {
                    action(propertyInfo, o);
                    return;
                }

                var item = Cache.GetOrAdd(t, key =>
                {
                    const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public;

                    var propertyInfos = key.GetProperties(FLAGS);

                    return new PropertyInfoCacheItem { LastAccessed = DateTime.Now, Type = key, PropertyInfos = propertyInfos };
                });

                item.LastAccessed = DateTime.Now;

                this.ProcessProperties(o, item.PropertyInfos, idGenerator, action);
            }
        }

        private static bool IsEnumerable(Type type)
        {
            if (type.FullName.StartsWith("System.Collections.Generic.List"))
                return true;
            return type.FullName.StartsWith("System.Collections.Generic.Dictionary") || type.IsArray;
        }

        private void ProcessProperties(object o, IEnumerable<PropertyInfo> pi, ObjectIDGenerator idGenerator, Action<PropertyInfo, object> action)
        {
            foreach (var prop in from prop in pi let indexerCount = prop.GetIndexParameters().Any() where !indexerCount select prop)
            {
                try
                {
                    this.ProcessMember(prop, prop.GetValue(o, null), idGenerator, action);
                }
                catch (TargetInvocationException)
                {
                }
            }
        }

        private void ProcessMember(PropertyInfo propertyInfo, object value, ObjectIDGenerator idGenerator, Action<PropertyInfo, object> action)
        {
            switch (value)
            {
                case JObject _:
                    action(propertyInfo, value);
                    return;
                case null:
                    action(propertyInfo, null);
                    break;
                default:
                    {
                        var type = value.GetType();
                        if (type.IsArray)
                            this.ProcessEnumerable(propertyInfo, value, idGenerator, action);
                        else if (type.IsValueType || type == typeof(string))
                            action(propertyInfo, value);
                        else if (type.IsClass)
                            this.Visit(propertyInfo, value, idGenerator, action);
                        else if (type.IsInterface)
                            action(propertyInfo, value);
                        break;
                    }
            }
        }

        private void ProcessEnumerable(PropertyInfo propertyInfo, object value, ObjectIDGenerator idGenerator, Action<PropertyInfo, object> action)
        {
            foreach (var o in (IEnumerable)value)
                this.ProcessMember(propertyInfo, o, idGenerator, action);
        }

        private class PropertyInfoCacheItem
        {
            public Type Type { get; set; }

            public PropertyInfo[] PropertyInfos { get; set; }

            public DateTime LastAccessed { get; set; }
        }
    }
}