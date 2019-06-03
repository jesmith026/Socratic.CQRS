using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Commands
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public Student Student { get; set; }

        public UpdateStudentCommand(Student student)
        {
            Student = student;
        }
    }
}