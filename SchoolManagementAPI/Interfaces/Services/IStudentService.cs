using SchoolManagementAPI.DTOs;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentAsync();
        Task<StudentDto> GetStudentByIdAsync(string id);
        Task CreateStudentAsync(CreateStudentRequest request);
        Task UpdateStudentAsync(string id, UpdateStudentRequest request);
        Task DeleteStudentAsync(string id);
    }
}
