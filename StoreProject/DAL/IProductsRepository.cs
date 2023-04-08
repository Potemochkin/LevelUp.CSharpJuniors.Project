using StoreProject.Api.DAL.Entities;

namespace StoreProject.Api.DAL
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAll();
        public Task<ProductEntity?> GetById(Guid id);
        public Task Create(ProductEntity entity);
        public Task Delete(Guid id);
        public Task Update(ProductEntity productEntity);
    }
}
