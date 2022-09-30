using System.Runtime.Serialization;

namespace Bff.Core.Framework.Exceptions
{
    [Serializable]
    public class DataConflictException : Exception
    {

        public DataConflictException()
        {
        }

        public DataConflictException(string messageKey, object exceptionData) : this(messageKey)
        {
            ExceptionData = exceptionData;
        }

        public DataConflictException(string messageKey, params string[] messageParams) : base(string.Format(messageKey, messageParams))
        {
        }

        public DataConflictException(string messageKey, Guid id) : base(string.Format(messageKey, id.ToString()))
        {
        }

        public DataConflictException(string messageKey, Guid id, Guid parentId) : base(string.Format(messageKey, id.ToString(), parentId.ToString()))
        {
        }

        public DataConflictException(string message) : base(message)
        {
        }

        public DataConflictException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DataConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object? ExceptionData { get; set; }
    }
}
