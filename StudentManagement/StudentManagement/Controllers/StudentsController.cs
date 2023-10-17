using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using StudentManagement.Models;
using StudentManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
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
            if ( student != null)
            {
                return student;
            }
            else { return NotFound($"Student not found for the {id}"); }
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            
            studentService.Create(student);
            
            return CreatedAtAction(nameof(Get),new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var Student1 = studentService.Get(id);
            if( Student1 == null) { return NotFound($"Student not found for the {id}"); }
            studentService.Update(id, student);
            return NoContent(); 

        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var Student2 = studentService.Get(id);
            if (Student2 == null) { return NotFound($"Student not found for the {id}"); }
            studentService.remove(id);
            return NoContent();
        }
        [Route("courses")]
        [HttpGet]
        public ActionResult<List<Course>> GetCourses()
        {
            return studentService.GetCourses();
        }





        [Route("courses")]
        [HttpPost]
        public ActionResult<Course> CreateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest(); // Return a 400 Bad Request if the course data is invalid.
            }

            // Add logic to create and save the course in your studentService.
            studentService.CreateCourse(course);

            return CreatedAtAction("GetCourses", new { id = course.Id }, course);
        }

        [Route("courses/{id}")]
        [HttpPut]
        public ActionResult<Course> UpdateCourse(string id, [FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }

            // Add logic to update the course in your studentService.
            studentService.UpdateCourse(id, course);

            return Ok(course);
        }


    }
}
