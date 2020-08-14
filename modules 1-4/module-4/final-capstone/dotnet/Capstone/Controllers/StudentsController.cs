using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDAO studentDao;

        public StudentsController(IStudentDAO studentDao)
        {
            this.studentDao = studentDao;
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListStudents()
        {
            return Ok(this.studentDao.GetStudents());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult StudentDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be positive");
            }

            Student student = this.studentDao.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [Authorize]
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            Student newStudent = this.studentDao.CreateStudent(student);

            return Created($"Students/{student.Id}", newStudent);
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            Student oldStudent = this.studentDao.GetStudent(student.Id);

            if (oldStudent == null)
            {
                return NotFound();
            }

            this.studentDao.UpdateStudent(student);

            return Ok(student);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student student = this.studentDao.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            this.studentDao.DeleteStudent(id);

            return NoContent();
        }
    }
}