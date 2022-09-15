using System.Linq.Expressions;
using System.Reflection;

namespace Bff.Domain.Model.Core.Framework
{
    public static class TypeExtensions
    {
        public static bool IsSystemType(this Type type) => type.Assembly == typeof(object).Assembly;

        public static MethodInfo MethodOf<T>(Expression<Func<T>> expression)
        {
            var body = (MethodCallExpression)expression.Body;
            return body.Method;
        }

        public static MethodInfo MethodOf(Expression<Action> expression)
        {
            var body = (MethodCallExpression)expression.Body;
            return body.Method;
        }

        public static ConstructorInfo? ConstructorOf<T>(Expression<Func<T>> expression)
        {
            var body = (NewExpression)expression.Body;
            return body.Constructor;
        }

        public static PropertyInfo PropertyOf<T>(Expression<Func<T>> expression)
        {
            var body = (MemberExpression)expression.Body;
            return (PropertyInfo)body.Member;
        }

        public static FieldInfo FieldOf<T>(Expression<Func<T>> expression)
        {
            var body = (MemberExpression)expression.Body;
            return (FieldInfo)body.Member;
        }

        public static MemberInfo DecodeMemberAccessExpressionOf<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property)
        {
            if (property is null)
                throw new ArgumentNullException(nameof(property));
            if (property.Body.NodeType == ExpressionType.MemberAccess)
                return ((MemberExpression)property.Body).Member;
            if (property.Body.NodeType == ExpressionType.Convert && property.Body.Type == typeof(TProperty))
                return ((MemberExpression)((UnaryExpression)property.Body).Operand).Member;

            throw new ArgumentException($"Invalid expression type: Expected ExpressionType.MemberAccess, Found {property.Body.NodeType}", nameof(property));
        }

        public static T? GetAttributeOfType<T>(Type type, string value) where T : Attribute
        {
            var memInfo = type.GetMember(value);
            return memInfo[0].GetCustomAttribute<T>(false);
        }

        public static bool IsOfType<T>(Type type) => type == typeof(T) || Nullable.GetUnderlyingType(type) == typeof(T);

        private static IEnumerable<PropertyInfo> GetPropertiesWithNewKeyWordCheck(this Type type)
        {
            var alreadyReturnedPropertyNames = new HashSet<string>();
            foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            {
                alreadyReturnedPropertyNames.Add(prop.Name);
                yield return prop;
            }

            if (type.BaseType is null)
                yield break;

            foreach (var prop in GetPropertiesWithNewKeyWordCheck(type.BaseType).Where(prop => !alreadyReturnedPropertyNames.Contains(prop.Name)))
                yield return prop;
        }

        public static IEnumerable<PropertyInfo> GetPropertiesWithoutNewProperties(this Type type)
        {
            var alreadyReturnedPropertyNames = new HashSet<string>();

            if (type.BaseType != null)
            {
                foreach (var prop in GetPropertiesWithNewKeyWordCheck(type.BaseType))
                {
                    alreadyReturnedPropertyNames.Add(prop.Name);
                    yield return prop;
                }
            }

            foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Where(p => !alreadyReturnedPropertyNames.Contains(p.Name)))
            {
                yield return prop;
            }
        }
    }
}
