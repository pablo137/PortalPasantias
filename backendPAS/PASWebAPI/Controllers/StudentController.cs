using Microsoft.AspNetCore.Mvc;
using PAS.Data.Repositories;
using PAS.Model;

namespace PASWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await _studentRepository.GetAllStudents());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDetails(int id)
        {
            return Ok(await _studentRepository.GetStudentDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _studentRepository.InsertStudent(student);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _studentRepository.UpdateStudent(student);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(new Student { Id = id});
            return NoContent();
        }
    }
    
}
