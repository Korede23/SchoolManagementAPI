using SchoolManagementAPI.DTOs;
using SchoolManagementAPI.Interfaces.Repositories;
using SchoolManagementAPI.Interfaces.Services;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task CreateStudentAsync(CreateStudentRequest request)
        {
            var student = new Student
            {
                Name = request.Name,
                Age = request.Age,
                Class = request.Class
            };

            await _studentRepository.CreateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            await _studentRepository.DeleteStudentAsync(id);    
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentAsync()
        {
            var students = await _studentRepository.GetAllStudentAsync();
            return students.Select(student => new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Class = student.Class
            });

        }

        public async Task<StudentDto> GetStudentByIdAsync(string id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student is null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Class = student.Class
            };
        }

        public async Task UpdateStudentAsync(string id, UpdateStudentRequest request)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student is null)
            {
                throw new KeyNotFoundException("Student Not Found");
            }

            student.Name = request.Name;
            student.Age = request.Age;
            student.Class = request.Class;

            await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
