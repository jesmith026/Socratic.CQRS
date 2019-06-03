using System.Collections.Generic;
using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Commands
{
    public class GetStudentsCommand : IRequest<IEnumerable<Student>>
    {
        
    }
}