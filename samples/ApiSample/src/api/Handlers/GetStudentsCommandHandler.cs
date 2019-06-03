using System.Collections.Generic;
using System.Threading.Tasks;
using api.Commands;
using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Handlers
{
    public class GetStudentsCommandHandler : IRequestHandler<GetStudentsCommand, IEnumerable<Student>>
    {
        public Task<IEnumerable<Student>> HandleAsync(GetStudentsCommand request)
        {
            var students = DbMock.GetAll<Student>();

            return Task.FromResult(students);
        }
    }
}