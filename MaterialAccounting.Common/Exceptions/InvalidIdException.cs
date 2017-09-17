using System;

namespace MaterialAccounting.Common.Exceptions
{
    public class InvalidIdException : ArgumentException
    {
        public long Id { get; private set; }

        public override string Message => string.Format("Invalid ID: {0}", Id);

        public InvalidIdException(long id)
        {
            Id = id;
        }
    }
}
