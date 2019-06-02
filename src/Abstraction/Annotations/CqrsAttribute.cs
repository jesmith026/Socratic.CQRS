using System;

namespace Socratic.CQRS.Abstractions.Annotations
{
    /// <summary>
    /// Abstract base class for all annotations used for CQRS
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public abstract class CqrsAttribute : Attribute
    {
        
    }
}