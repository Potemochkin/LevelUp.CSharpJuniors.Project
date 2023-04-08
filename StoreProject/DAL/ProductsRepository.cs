using Microsoft.EntityFrameworkCore;
using StoreProject.Api.DAL.Entities;
using StoreProject.Api.Models;

namespace StoreProject.Api.DAL
{
    public sealed class ProductsRepository : IProductsRepository // для технической функции
    {

        private readonly ProductsDbContext _dbContext; //это слепок нашей БД, модель

        public ProductsRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
               
        public Task<IEnumerable<ProductEntity>> GetAll() // это трансляция запроса из бизнес слоя в sql запрос. Для получения данных и отдачи обратно
        {
            // return Task.FromResult(Enumerable.Empty<ProductEntity>());

            return Task.FromResult<IEnumerable<ProductEntity>>(_dbContext.Products!.ToList());
        }

         public async Task Create(ProductEntity entity)
        {
           await _dbContext.Products!.AddAsync(entity);
           await _dbContext.SaveChangesAsync(); //после этого сгенерируется sql код, который создаст entity внутри БД
        }

        public Task<ProductEntity?> GetById(Guid id) //Создаем в репозитории этот метод, где из контекста выдергиваем конкретный элемент
        {
            return _dbContext.Products!
                .FirstOrDefaultAsync(e => e.Id.Equals(id));

        }

        public async Task Delete(Guid id)
        {
            var entity = await _dbContext.Products!.FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (entity != null)
            _dbContext.Products!.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ProductEntity productEntity)
        {
            _dbContext.Products!.Update(productEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
