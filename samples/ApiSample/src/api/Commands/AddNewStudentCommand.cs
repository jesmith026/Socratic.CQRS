using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Commands
{
    public class AddNewStudentCommand : IRequest<int>
    {
        public Student Student { get; set; }

        public AddNewStudentCommand(Student student)
        {
            Student = student;
        }
    }
}