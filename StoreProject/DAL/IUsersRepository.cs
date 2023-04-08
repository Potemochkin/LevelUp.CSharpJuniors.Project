using StoreProject.Api.DAL.Entities;

namespace StoreProject.Api.DAL
{
    public interface IUsersRepository
    {       
            public Task<IEnumerable<UserEntity>> GetAllUsers();
            public Task<UserEntity?> GetUserById(Guid id);
            public Task Create(UserEntity userEntity);        
    }
}
