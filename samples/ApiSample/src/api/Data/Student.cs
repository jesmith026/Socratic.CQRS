
using System.Collections.Generic;

namespace api.Data
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }        
    }
}