using System;

namespace MaterialAccounting.Common.Exceptions
{
    public class IdNotExistsException : ArgumentException
    {
        public long Id { get; private set; }

        public override string Message => string.Format(
            "Invalid model ID provided: impossible to find a model using this ID: {0}",
            Id);

        public IdNotExistsException(long id)
        {
            Id = id;
        }
    }
}
