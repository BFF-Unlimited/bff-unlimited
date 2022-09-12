﻿using Microsoft.Extensions.Logging;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Domain.Model.Core.Framework
{

    public abstract class HandlerBase 
    {
        [Inject]
        public IKernel Kernel { get; set; }

        [Inject]
        public IRovictLogger Logger { get; set; }

        [DebuggerStepThrough]
        protected void AssertHasAccess()
        {
            //var permissions = this.AttributePermissionFactory.CreateAccessPermissionInstancesFor(this, this.Container);
            //if (permissions.Count == 0 || permissions.Any(permission => permission.HasAccess()))
            //    return;

            //throw new ForbiddenException(ApplicationServerErrorMessages.NO_PERMISSION_TO_PERFORM_ACTION);
        }

        [DebuggerStepThrough]
        protected static void GuardHandler(object request)
        {
            Guard.NotNull(request);

            var defaultStringLengthAttribute = new StringLengthAttribute(255);

            var visitor = new ObjectVisitor();
            visitor.VisitProperties(request, (pi, value) =>
            {
                if (pi is null || !pi.CanWrite || !(value is string s))
                    return;

                // Ignore readonly fields
                var readOnlyAttribute = pi.GetCustomAttribute<ReadOnlyAttribute>(true);
                if (readOnlyAttribute != null && readOnlyAttribute.IsReadOnly)
                    return;

                var stringLengthAttribute = pi.GetCustomAttribute<StringLengthAttribute>(true) ?? defaultStringLengthAttribute;
                if (s.Length > stringLengthAttribute.MaximumLength)
                    throw new ForbiddenException("De ingevoerde tekst '{0}' is te lang. Maximale lengte is {1}.", pi.Name, stringLengthAttribute.MaximumLength.ToString());
            });
        }
    }
}
