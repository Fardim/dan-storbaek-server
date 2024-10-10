using dan_storbaek_server.Domains;

namespace dan_storbaek_server.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(string id);
        Task<User?> CreateAsync(User newUser);
        Task<User?> UpdateAsync(string id, User updatedUser);
        Task<bool> RemoveAsync(string id);
    }
}
