using dan_storbaek_server.Domains;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dan_storbaek_server.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _usersCollection;
        public UserService(IOptions<DanTestDatabaseSettings> danTestDatabaseSettings)
        {
            var mongoClient = new MongoClient(danTestDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(danTestDatabaseSettings.Value.DatabaseName);
            _usersCollection = mongoDatabase.GetCollection<User>(danTestDatabaseSettings.Value.UsersCollectionName);
        }
        public async Task<User?> CreateAsync(User newUser)
        {
            await _usersCollection.InsertOneAsync(newUser);
            return await GetUserById(newUser.Id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersCollection.Find(d => true).ToListAsync();
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _usersCollection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveAsync(string id)
        {
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }

        public async Task<User?> UpdateAsync(string id, User updatedUser)
        {
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);
            return await GetUserById(id);
        }
    }
}
