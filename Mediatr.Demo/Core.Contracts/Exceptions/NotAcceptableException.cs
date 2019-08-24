using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Contracts.Exceptions
{
    public class NotAcceptableException : Exception
    {
        public NotAcceptableException()
        {
        }

        public NotAcceptableException(string message) : base(message)
        {
        }

        public NotAcceptableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAcceptableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
