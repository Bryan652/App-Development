# This is for App Development Notes and Codes

--- 

## Week 1 - 3
notes 
``` bash
Nothing.....
```

codes 
``` c#
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // In-memory data store for demo purposes
        private static readonly List<Student> Students = new List<Student>();

        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(Students); // 200 OK
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404 Not Found

            return Ok(student); // 200 OK
        }

        // POST: api/students
        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            if (student == null)
                return BadRequest(); // 400 Bad Request

            student.Id = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1;
            Students.Add(student);

            // 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Student updatedStudent)
        {
            if (updatedStudent == null || updatedStudent.Id != id)
                return BadRequest(); // 400 Bad Request

            var existingStudent = Students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
                return NotFound(); // 404 Not Found

            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;

            return NoContent(); // 204 No Content
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(); // 404 Not Found

            Students.Remove(student);
            return NoContent(); // 204 No Content
        }
    }

    // Simple model
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
```

--- 

