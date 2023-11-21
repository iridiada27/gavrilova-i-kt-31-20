using Prpr.Database;
using Prpr.Filters.StudentFilters;
using Prpr.Interfaces.StudentInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prpr.Models;
using Prpr.Filters.StudentFilters;
using System.Text.RegularExpressions;

namespace Prpr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        public Marks _dbcontext;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService, Marks context)
        {
            _logger = logger;
            _studentService = studentService;
            _dbcontext = context;
        }
        [HttpPost(Name = "GetStudentsBuGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken)
        {

            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost("AddStudent", Name = "AddStudent")]
        public IActionResult CreateStudent([FromBody] StudentAddFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = new Student();
            student.Name = filter.Name;
            student.Surname = filter.Surname;
            student.Otchestvo = filter.Otchestvo;
            student.GroupId = _dbcontext.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;

            _dbcontext.Set<Student>().Add(student);
            _dbcontext.SaveChanges();
            return Ok(student);
        }

        [HttpPut("EditStudent")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentAddFilter filter)
        {
            var existingStudent = _dbcontext.Set<Student>().FirstOrDefault(g => g.StudentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = filter.Name;
            existingStudent.Surname = filter.Surname;
            existingStudent.Otchestvo = filter.Otchestvo;
            existingStudent.GroupId = _dbcontext.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;
            _dbcontext.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteGroup(int id)
        {
            var existingStudent = _dbcontext.Set<Student>().FirstOrDefault(g => g.StudentId == id);

            if (existingStudent == null)
            {
                return NotFound();
            }
            _dbcontext.Set<Student>().Remove(existingStudent);
            _dbcontext.SaveChanges();

            return Ok();
        }
    }
}
