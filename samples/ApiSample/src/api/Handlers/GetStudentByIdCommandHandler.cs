using System.Collections.Generic;
using System.Threading.Tasks;
using api.Commands;
using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Handlers
{
    public class GetStudentByIdCommandHandler : IRequestHandler<GetStudentByIdCommand, Student>
    {
        public Task<Student> HandleAsync(GetStudentByIdCommand request)
        {
            var student = DbMock.FindOne<Student>(request.StudentId);

            if (student == null)
                throw new KeyNotFoundException($"Student not found with ID {student.Id}");
            
            return Task.FromResult(student);
        }
    }
}