using System.Diagnostics;
using System.Runtime.Serialization;

namespace Bff.Domain.Model.Core.Framework.Exceptions
{


    [Serializable]
    public class ForbiddenException : Exception
    {

        public ForbiddenException()
        {
        }

        public ForbiddenException(string messageKey, object exceptionData) : this(messageKey)
        {
            ExceptionData = exceptionData;
        }

        public ForbiddenException(string messageKey, params string[] messageParams) : base(string.Format(messageKey, messageParams))
        {
        }

        public ForbiddenException(string messageKey, Guid id) : base(string.Format(messageKey, id.ToString()))
        {
        }

        public ForbiddenException(string messageKey, Guid id, Guid parentId) : base(string.Format(messageKey, id.ToString(), parentId.ToString()))
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object? ExceptionData { get; set; }
    }
}
