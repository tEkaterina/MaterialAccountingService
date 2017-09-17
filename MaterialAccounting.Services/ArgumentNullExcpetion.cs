using System;
using System.Runtime.Serialization;

namespace MaterialAccounting.Services
{
    [Serializable]
    internal class ArgumentNullExcpetion : Exception
    {
        public ArgumentNullExcpetion()
        {
        }

        public ArgumentNullExcpetion(string message) : base(message)
        {
        }

        public ArgumentNullExcpetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentNullExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}