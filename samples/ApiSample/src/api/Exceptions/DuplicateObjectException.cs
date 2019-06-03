using System;
using api.Data;

namespace api.Exceptions
{
    public class DuplicateObjectException : Exception
    {
        public DuplicateObjectException(IEntity record)
            : base($"Object of type {record.GetType().Name} with Id {record.Id} already exists.")
        {}
    }
}