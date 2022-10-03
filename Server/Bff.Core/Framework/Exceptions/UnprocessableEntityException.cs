using System.Runtime.Serialization;

namespace Bff.Core.Framework.Exceptions
{
    [Serializable]
    public class UnprocessableEntityException : Exception
    {

        public UnprocessableEntityException()
        {
        }

        public UnprocessableEntityException(string messageKey, object exceptionData) : this(messageKey)
        {
            ExceptionData = exceptionData;
        }

        public UnprocessableEntityException(string messageKey, params string[] messageParams) : base(string.Format(messageKey, messageParams))
        {
        }

        public UnprocessableEntityException(string messageKey, Guid id) : base(string.Format(messageKey, id.ToString()))
        {
        }

        public UnprocessableEntityException(string messageKey, Guid id, Guid parentId) : base(string.Format(messageKey, id.ToString(), parentId.ToString()))
        {
        }

        public UnprocessableEntityException(string message) : base(message)
        {
        }

        public UnprocessableEntityException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UnprocessableEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object? ExceptionData { get; set; }
    }
}
