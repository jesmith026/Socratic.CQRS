using System;
using Socratic.CQRS.Abstractions.Annotations;

namespace Socratic.CQRS.Annotations
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class AuditAttribute : CqrsAttribute
    {
    }
}