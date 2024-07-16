using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);
    }
}
