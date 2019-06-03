using System.Collections.Generic;
using api.Data;
using Socratic.CQRS.Abstractions;

namespace api.Commands
{
    public class GetStudentByIdCommand : IRequest<Student>
    {
        public int StudentId { get; set; }
        
        public GetStudentByIdCommand(int studentId)
        {
            StudentId = studentId;
        }        
    }
}