using Microsoft.AspNetCore.Mvc;
using SR_WebAPI_Application.Interfaces;
using SR_WebAPI_Application.Services;
using SR_WebAPI_Domain.Entities;

namespace SR_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService  _studentService;
        private readonly ILogger _logger;   
        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<Tuple<List<Student>, int>>> GetStudentsList(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var result = await _studentService.GetStudentsList(pageNumber, pageSize);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error found when retrieving a list of all students.");
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult<bool>> CreateStudent([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _studentService.CreateStudent(student);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error found when creating a new student.");
                return BadRequest(ex.Message);
            }
        }

   
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateStudent([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _studentService.UpdateStudent(student);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error found when updating the existing student with Id {student.Id}.");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            try
            {
                var result = await _studentService.DeleteStudent(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error found when deleting the student with Id {id}.");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await _studentService.GetStudent(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error found when getting the student with Id {id}.");
                return BadRequest(ex.Message);
            }
        }
    }    
}
