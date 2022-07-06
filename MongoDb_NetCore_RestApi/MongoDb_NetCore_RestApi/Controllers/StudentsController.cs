using Microsoft.AspNetCore.Mvc;
using MongoDb_NetCore_RestApi.Models;
using MongoDb_NetCore_RestApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDb_NetCore_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return studentService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = studentService.Get(id);
            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found!");
            }
            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentService.Create(student);

            return CreatedAtAction(nameof(Get), new {id = student.Id}, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = studentService.Get(id);

            if (existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found!");
            }

            studentService.Update(id, existingStudent);
            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = studentService.Get(id);

            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found!");
            }

            studentService.Remove(student.Id);

            return Ok($"Student with Id = {id} is deleted successfully");
        }
    }
}
