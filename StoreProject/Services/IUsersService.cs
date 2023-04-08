using StoreProject.Api.Models;

namespace StoreProject.Api.Services
{
    public interface IUsersService
    {
        Task<User?> GetUserById(Guid id);
        Task<IEnumerable<User>> GetUsers();
        Task AddUsers(User user);
    }
}
