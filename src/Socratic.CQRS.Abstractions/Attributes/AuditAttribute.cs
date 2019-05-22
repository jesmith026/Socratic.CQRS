using System;

namespace Socratic.CQRS.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class AuditAttribute : CqrsAttribute
    {
    }
}