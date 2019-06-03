using Socratic.CQRS.Abstractions;

namespace api.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int StudentId { get; set; }

        public DeleteStudentCommand(int studentId)
        {
            StudentId = studentId;
        }
    }
}