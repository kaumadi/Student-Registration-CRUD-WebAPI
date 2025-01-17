using SR_WebAPI_Domain.Entities;

namespace SR_WebAPI_Application.Interfaces
{
    public interface IStudentService
    {
        Task<Tuple<List<Student>, int>> GetStudentsList(int page, int pageSize);
        Task<bool> CreateStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);        
        Task<Student> GetStudent(int id);
    }
}
