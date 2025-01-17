using SR_WebAPI_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_WebAPI_Domain.Interfaces
{
    public interface IStudentReporitory
    {
        Task<Tuple<List<Student>, int>> GetStudentsList(int page, int pageSize);
        Task<bool> CreateStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);
        Task<Student> GetStudent(int id);
    }
}
