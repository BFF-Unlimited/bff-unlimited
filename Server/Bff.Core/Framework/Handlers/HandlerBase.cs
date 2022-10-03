using Bff.Core.Framework.Exceptions;
using Bff.Core.Framework.Extensions;
using Bff.Core.Framework.Logging;
using Ninject;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace Bff.Core.Framework.Handlers
{

    public abstract class HandlerBase : IHandler
    {
        [Inject]
        public IKernel? Kernel { get; set; }

        [Inject]
        public IRovictLogger? Logger { get; set; }

        [DebuggerStepThrough]
        protected static void GuardHandler(object request)
        {
            Guard.NotNull(request);

            var defaultStringLengthAttribute = new StringLengthAttribute(255);

            var visitor = new ObjectVisitor();
            visitor.VisitProperties(request, (pi, value) =>
            {
                if (pi is null || !pi.CanWrite || value is not string s)
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

        public virtual void Initialize()
        {
            Guard.NotNull(Logger);
            Guard.NotNull(Kernel);
        }
    }
}
