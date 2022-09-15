using System.Diagnostics;
using System.Runtime.Serialization;

namespace Bff.Core.Framework.Exceptions
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message) : base(message)
        { }

        public UnauthorizedException(string messageKey, params string[] messageParams) : base(string.Format(messageKey, messageParams))
        { }

        public UnauthorizedException(string messageKey, Guid id) : base(string.Format(messageKey, id.ToString()))
        { }

        public UnauthorizedException(string messageKey, Guid id, Guid parentId) : base(string.Format(messageKey, id.ToString(), parentId.ToString()))
        { }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
