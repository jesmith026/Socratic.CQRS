using System.Collections.Generic;
using System.Threading.Tasks;
using api.Commands;
using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        public Task<bool> HandleAsync(DeleteStudentCommand request)
        {
            DbMock.Delete<Student>(request.StudentId);
            
            return Task.FromResult(true);
        }
    }
}