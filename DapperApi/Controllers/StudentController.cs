using Microsoft.AspNetCore.Mvc;
using DapperApi.Models;
using DapperApi.Repositories;

namespace DapperApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            var students = _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _studentRepository.GetbyId(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _studentRepository.Create(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            var existingStudent = _studentRepository.GetbyId(id);
            if (existingStudent == null)
                return NotFound();

            _studentRepository.Update(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _studentRepository.GetbyId(id);
            if (existingStudent == null)
                return NotFound();

            _studentRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("with-courses")]
        public ActionResult<IEnumerable<StudentWithCourses>> GetAllWithCourses()
        {
            var studentsWithCourses = _studentRepository.GetAllWithCourses();
            return Ok(studentsWithCourses);
        }
    }
}