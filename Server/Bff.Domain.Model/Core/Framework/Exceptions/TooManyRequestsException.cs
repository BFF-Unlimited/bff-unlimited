using System.Runtime.Serialization;

namespace Bff.Domain.Model.Core.Framework.Exceptions
{
    [Serializable]
    public class TooManyRequestsException : Exception
    {

        public TooManyRequestsException()
        {
        }

        public TooManyRequestsException(string messageKey, object exceptionData) : this(messageKey)
        {
            ExceptionData = exceptionData;
        }

        public TooManyRequestsException(string messageKey, params string[] messageParams) : base(string.Format(messageKey, messageParams))
        {
        }

        public TooManyRequestsException(string messageKey, Guid id) : base(string.Format(messageKey, id.ToString()))
        {
        }

        public TooManyRequestsException(string messageKey, Guid id, Guid parentId) : base(string.Format(messageKey, id.ToString(), parentId.ToString()))
        {
        }

        public TooManyRequestsException(string message) : base(message)
        {
        }

        public TooManyRequestsException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TooManyRequestsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object? ExceptionData { get; set; }
    }
}
