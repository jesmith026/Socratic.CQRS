using System.Collections.Generic;
using System.Threading.Tasks;
using api.Commands;
using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        public Task<bool> HandleAsync(UpdateStudentCommand request)
        {
            DbMock.Update(request.Student);
            return Task.FromResult(true);
        }
    }
}