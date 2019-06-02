using System;

namespace Socratic.CQRS.Exceptions
{
    public class UnregisteredAttributeException: Exception
    {
        public UnregisteredAttributeException() : base("Unregistered CQRS attribute encountered."){}

        public UnregisteredAttributeException(Type attribute) 
            : base($"Unregistered CQRS attribute {attribute.Name} encountered."){}

        public UnregisteredAttributeException(Type attribute, Exception innerException) 
            : base($"Unregistered CQRS attribute {attribute.Name} encountered.", innerException) {}
    }
}