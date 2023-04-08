using StoreProject.Api.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace StoreProject.Api.DAL
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProductsDbContext _dbContext; // слепок БД

        public UsersRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(UserEntity userEntity)
        {
            await _dbContext.Users!.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return Task.FromResult<IEnumerable<UserEntity>>(_dbContext.Users!.ToList());
        }

        public Task<UserEntity?> GetUserById(Guid id)
        {
            return _dbContext.Users!.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }
    }
}
