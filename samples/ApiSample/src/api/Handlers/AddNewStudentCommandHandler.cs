using System.Collections.Generic;
using System.Threading.Tasks;
using api.Commands;
using api.Data;
using Socratic.CQRS.Abstractions;
using Socratic.CQRS.Annotations;

namespace api.Handlers
{
    [Audit]
    public class AddNewStudentCommandHandler : IRequestHandler<AddNewStudentCommand, int>
    {
        public Task<int> HandleAsync(AddNewStudentCommand request)
        {
            DbMock.Add(request.Student);
            
            return Task.FromResult(request.Student.Id);
        }
    }
}