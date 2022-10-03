using System.Runtime.Serialization;

namespace Bff.Core.Framework.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : Exception
    {

        public ResourceNotFoundException()
        {
        }

        public ResourceNotFoundException(string messageKey, object exceptionData) : this(messageKey)
        {
            ExceptionData = exceptionData;
        }

        public ResourceNotFoundException(string messageKey, params string[] messageParams) : base(string.Format(messageKey, messageParams))
        {
        }

        public ResourceNotFoundException(string messageKey, Guid id) : base(string.Format(messageKey, id.ToString()))
        {
        }

        public ResourceNotFoundException(string messageKey, Guid id, Guid parentId) : base(string.Format(messageKey, id.ToString(), parentId.ToString()))
        {
        }

        public ResourceNotFoundException(string message) : base(message)
        {
        }

        public ResourceNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object? ExceptionData { get; set; }
    }
}
