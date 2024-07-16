using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SchoolManagementAPI.Configuration;

namespace SchoolManagementAPI.DbContext
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<AppSettings> settings)
        {
            //var client = new MongoClient(settings.Value.ConnectionString);   
            //_database = client.GetDatabase(settings.Value.DatabaseName);
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                _database = client.GetDatabase(settings.Value.DatabaseName);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine($"An error occurred while connecting to MongoDB: {ex.Message}");
                throw;
            }
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
