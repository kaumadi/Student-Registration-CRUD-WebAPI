using Microsoft.Extensions.Logging;
using SR_WebAPI_Application.Interfaces;
using SR_WebAPI_Domain.Entities;
using SR_WebAPI_Domain.Interfaces;

namespace SR_WebAPI_Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentReporitory _registerrepository;
        private readonly ILogger _logger;
        public StudentService(IStudentReporitory registerReporitory, ILogger<StudentService> logger)
        {
            _registerrepository= registerReporitory;
            _logger= logger;    
        }
        public async Task<Tuple<List<Student>, int>> GetStudentsList(int page, int pageSize)
        {
            try
            {
                return await _registerrepository.GetStudentsList( page, pageSize); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error found when retrieving a list of all students.");
                throw;
            }
        }
        public async Task<Student> GetStudent(int id)
        {
            try
            {
                return await _registerrepository.GetStudent(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error found when getting the student with ID {id}.");
                throw;
            }
        }
        public async Task<bool> CreateStudent(Student student)
        {
            try
            {
                return await _registerrepository.CreateStudent(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error found when creating a new student.");
                throw;
            }
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            try
            {
                return await _registerrepository.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error found when updating the student with ID {student.Id}.");
                throw;
            }
        }
        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                return await _registerrepository.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error found when deleting the student with ID {id}.");
                throw;
            }
        }



    }
}
