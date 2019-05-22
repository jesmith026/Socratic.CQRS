using System;
using Socratic.CQRS.Abstractions.Attributes;

namespace Socratic.CQRS.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class AuditAttribute : CqrsAttribute
    {
    }
}