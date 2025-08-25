# This is for App Development Notes and Codes

--- 

## Week 1 - 3

## notes 
``` bash
Documentation for the ASP.NET
https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-9.0
```

### API
* An API (Application Programming Interface) is a set of rules that allows software components to communicate

### Importance of API: 
* Connects different applications
* Enables automation
* Power Integrations (e.g., Google Maps in apps)
Examples Facebook Graph API, Stripe Payment API, Weather Data APIs

### Rest API
* REST = Representational State Transfer
* Stateless Communication
* Uses standard HTTP methods (GET, POST, PUT, DELETE)
* Resource-based URLs
* Data Format: Usually JSON (sometimes XML)

### Common HTTP Methods 
* GET - Retrieve Data
* POST - Create Data
* PUT - Update Data
* DELETE - Remove Data 

### HTTP Status codes 
* 200 OK - Success
* 201 Created - Resource created
* 400 Bad Request - invalid Request
* 404 Not Found - Resource missing
* 500 Internal Server Error - Server Issue
* A cross-platform, open-source framework for building modern applications. It runs on windows, macOS, and Linus. Uses c# for primary language

<table>
  <tr>
    <td rowspan="2">Controllers</td>
    <td>Classes that handle incoming HTTP requests and send responses back to the client</td>
  </tr>
  <tr>
    <td>Defines API endpoints using HTTP verbs like GET, POST, PUT, DELETE</td>
  </tr>
  <tr>
    <td rowspan="2">Routing </td>
    <td>Matching URL paths to controller actions</td>
  </tr>
  <tr>
    <td>Default route format: /api/[controller]/[action]</td>
  </tr>
    <tr>
    <td rowspan="3">Action Methods </td>
    <td>Action = method in controller that handles a request</td>
  </tr>
  <tr>
    <td>Decorated with attributes: [HttpGet] [HttpPost] [HttpPut] [HttpDelete]</td>
  </tr>
    <tr>
    <td>Can take parameters from: 
        * URL Path
        * Query string
        * Request Body
    </td>
  </tr>
    <tr>
    <td rowspan="2">Models</td>
    <td>Classes that represent the structure of your data</td>
  </tr>
  <tr>
    <td>Defines how your API stores and transfers data</td>
  </tr>
    <tr>
    <td rowspan="2">Program.cs</td>
    <td>The main entry point of the ESP.NET Core application</td></td>
  </tr>
  <tr>
    <td>Builds and runs the web application, sets up services and middleware</td>
  </tr>
    <tr>
    <td rowspan="2">appSettings.json</td>
    <td>Configuration file for the application</td>
  </tr>
  <tr>
    <td>Stores settings like database connection, API keys, or logging settings in JSON format.</td>
  </tr>
    <tr>
    <td rowspan="2">appsettings.Development.json</td>
    <td>Environment-specific configuration file for development mode.</td>
  </tr>
  <tr>
    <td>Overrides settings in appsetting.json when running in development</td>
  </tr>
    <tr>
    <td rowspan="2">Properties/launchSettings.json</td>
    <td>File containing profiles for how the app run locally.</td>
  </tr>
  <tr>
    <td>Specifies ports, URLs, and environment variables for debugging </td>
  </tr>
</table>

## codes 
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

## notes
### What is Model?
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

## codes 
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

