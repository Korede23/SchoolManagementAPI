using MongoDB.Driver;
using SchoolManagementAPI.DbContext;
using SchoolManagementAPI.Interfaces.Repositories;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;
        public StudentRepository(IMongoDbContext context)
        {
            _students = context.GetCollection<Student>("Students");
        }

        public async Task CreateStudentAsync(Student student)
        {
            await _students.InsertOneAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            await _students.DeleteOneAsync(student => student.Id == id);
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            var students =  await _students.Find(student => true).ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            var studentData = await _students.Find(student => student.Id == id).FirstOrDefaultAsync();
            return studentData;
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _students.ReplaceOneAsync(s => s.Id == student.Id, student);
        }
    }
}
