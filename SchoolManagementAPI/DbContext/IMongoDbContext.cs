using MongoDB.Driver;

namespace SchoolManagementAPI.DbContext
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
