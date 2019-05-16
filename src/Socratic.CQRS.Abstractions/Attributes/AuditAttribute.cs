using System;

namespace Socratic.CQRS.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class AuditAttribute : Attribute
    {
        public AuditAttribute() 
        {}
    }
}