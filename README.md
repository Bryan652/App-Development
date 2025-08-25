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

## Week 4 - 5
notes 
```bash
What is Model?
* Represents data structure
* Maps to database entities or request objects
Example: Student, Product, Registration Form

What is Data Binding
* JSON -> Model Mapping
* Automatic conversion by ASP.NET Core
Example: { "username" : "Bryan" } -> RegistrationModel.username

Data Annotations
* [Required] -> Field must not be null/empty
* [StringLength(50)] -> Limit String size
* [Range(1, 100)] -> Restrict numeric range
* [EmailAddress] -> must be valid email format 
* [RegularExpression()] -> pattern matching

What is Model Validation
* Ensure Data Correctness
* Prevents invalid input from breaking app
* Uses Data Annotations (Required, EmailAddress, MinLength, Compare, etc)
```

codes 
``` c#

```

### Machine Problem 
* Create a registration API with validation
* Fields: FirstName, LastName, Email, Password, ConfirmPassword, Age
* Apply rules: required fields, email format, password, confirmation, minimum age 18

--- 

## Connecting ASP.NET to database 
* EF Core = ORM (Object Relational Mapper) 
* Maps Database tables to C# classes
* Eliminates most SQL writing
* Database is Designed first
* EF Core generates models and DbContext
* Useful if database already exists
* In Database-First, we scaffold models fron an existing database.
* This command generates models and DbContext
* Scaffold-DbContext
``` bash
"Server=;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
```
* central class for EF Core
* Represents database connection
* Exposes DbSet<T> for tables

### Machine Problem 
* Using EF Core, Connect your API to a Database (MS SQL SERVER)
* Build a simple CRUD API for database table of your choice
* User DB First Approach 

