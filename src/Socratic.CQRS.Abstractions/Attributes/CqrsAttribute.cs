using System;

namespace Socratic.CQRS.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public abstract class CqrsAttribute : Attribute
    {
        
    }
}