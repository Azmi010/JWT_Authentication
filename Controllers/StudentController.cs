using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using jwt.Models;

namespace jwt.Controllers
{
    public class StudentController : Controller
    {
        private string __constr;
        public StudentController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("api/student")]
        public ActionResult<Student> ListStudent()
        {
            StudentContext context = new StudentContext(this.__constr);
            List<Student> ListPerson = context.ListStudent();
            return Ok(ListPerson);
        }
        [HttpPost("api/student_auth"), Authorize]
        public ActionResult<Student> ListStudentWithAuth()
        {
            StudentContext context = new StudentContext(this.__constr);
            List<Student> ListPerson = context.ListStudent();
            return Ok(ListPerson);
        }
        [HttpPost("api/add_student_auth"), Authorize]
        public ActionResult<Student> AddStudentWithAuth([FromBody] Student student)
        {
            StudentContext context = new StudentContext(this.__constr);
            context.AddStudent(student);
            return Ok();
        }
        [HttpPut("api/update_student_auth/{id}"), Authorize]
        public ActionResult<Student> UpdateStudent(int id, Student student)
        {
            StudentContext context = new StudentContext(this.__constr);
            context.UpdateStudent(id, student);
            return Ok();
        }
        [HttpDelete("api/delete_student_auth/{id}"), Authorize]
        public ActionResult<Student> DeleteStudent(int id)
        {
            StudentContext context = new StudentContext(this.__constr);
            context.DeleteStudent(id);
            return NoContent();
        }
    }
}
