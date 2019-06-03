using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Commands;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Socratic.CQRS.Abstractions;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IBroker broker;

        public StudentsController(IBroker broker)
        {
            this.broker = broker;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var cmd = new GetStudentsCommand();
            var result = broker.Dispatch(cmd);

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var cmd = new GetStudentByIdCommand(id);
            var result = broker.Dispatch(cmd);

            return Ok(result);
        }        

        // POST api/values
        [HttpPost]
        public int Post([FromBody] Student student)
        {
            var cmd = new AddNewStudentCommand(student);
            var result = broker.Dispatch(cmd);
            return result;
        }

        // PUT api/values/5
        [HttpPut]
        public bool Put(Student student)
        {
            var cmd = new UpdateStudentCommand(student);
            var result = broker.Dispatch(cmd);
            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var cmd = new DeleteStudentCommand(id);
            var result = broker.Dispatch(cmd);
            return result;
        }
    }
}
