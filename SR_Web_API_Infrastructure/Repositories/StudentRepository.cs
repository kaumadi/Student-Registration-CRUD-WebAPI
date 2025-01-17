using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SR_WebAPI_Domain.Entities;
using SR_WebAPI_Domain.Interfaces;
using SR_WebAPI_Infrastructure.Context;
using System.Threading.Tasks;

namespace SR_WebAPI_Infrastructure.Repositories
{
    public class StudentRepository : IStudentReporitory
    {
        public readonly AppDBContext _context;
        private readonly ILogger<StudentRepository> _logger;
        public StudentRepository(AppDBContext applicationDBContext, ILogger<StudentRepository> logger)
        {
            _context = applicationDBContext;
            _logger = logger;
        }


        public async Task<bool> CreateStudent(Student student)
        {
             try
                {
                    Student studentToAdd = new Student
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Mobile = student.Mobile,
                        Email = student.Email,
                        NIC = student.NIC,
                        DateOfBirth = student.DateOfBirth,
                        Address = student.Address,
                        ImagePath = student.ImagePath 
                    };

                    _context.Students.Add(studentToAdd);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error captured when creating student:", ex.Message);
                    return false;
                }
            
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            try
            {
                var student = await _context.Students.FindAsync(Id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error captured when deleting student with ID {Id}: ", Id, ex.Message);
                return false;
            }
        }
        public async Task<Tuple<List<Student>, int>> GetStudentsList(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var totalItems = await _context.Students.CountAsync();
                var students = await _context.Students.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                return new Tuple<List<Student>, int>(students, totalItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error captured while retrieving students:", ex.Message);
                return new Tuple<List<Student>, int>(new List<Student>(), 0);
            }
        }
        public async Task<Student> GetStudent(int id)
        {
            try
            {
                return await _context.Students.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error captured while retrieving student with ID {Id}: ", id, ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            try
            {
                var std = await _context.Students.FindAsync(student.Id);
                if (std != null)
                {
                    std.FirstName = student.FirstName;
                    std.Mobile = student.FirstName;
                    std.Mobile = student.Mobile;
                    std.NIC = student.NIC;
                    std.Address = student.Address;
                    std.DateOfBirth = student.DateOfBirth;
                    std.Email = student.Email;
                    std.ImagePath = student.ImagePath;

                    _context.Students.Update(std);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error captured while updating student ID {Id}: ", student.Id, ex.Message);
                return false;
            }
        }

    }
}
