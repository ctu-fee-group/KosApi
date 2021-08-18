using System;
using System.Runtime.Serialization;

namespace Kos
{
    public class CacheEntryNotFoundException : Exception
    {
        public CacheEntryNotFoundException()
        {
        }

        protected CacheEntryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public CacheEntryNotFoundException(string? message) : base(message)
        {
        }

        public CacheEntryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}