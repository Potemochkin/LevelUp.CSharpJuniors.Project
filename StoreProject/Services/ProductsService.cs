using StoreProject.Api.DAL;
using StoreProject.Api.DAL.Entities;
using StoreProject.Api.Models;

namespace StoreProject.Api.Services
{
    public sealed class ProductsService : IProductsService //Это проверки для сервисного слоя
    {

       private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository) 
        {
           _productsRepository = productsRepository;
        }   

        public async Task<IEnumerable<ProductItem>> GetProducts() //Для получения всех
        {
            var entities = await _productsRepository.GetAll();
            return entities.Select(ProductItem.FromEntity);
        }

        public async Task AddProduct(ProductItem productItem) //Для получения по значению
        {
            var productEntity = new ProductEntity
            {
                Id = productItem.Id,
                CategoryId = productItem.CategoryId,
                Name = productItem.Name,
                Description = productItem.Description
            };
            await _productsRepository.Create(productEntity);
        }

        public async Task<ProductItem?> GetProductById(Guid productId)  //Проксируем вызов с контроллера, сюда пришел productId
        {
           var productEntity = await _productsRepository.GetById(productId); //Идем в репозиторий и получаем продукт энтити
            return productEntity == null ? null : ProductItem.FromEntity(productEntity); //делаем из него product item
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productsRepository.Delete(id);
        }

        public async Task UpdateProduct(ProductItem productItem)
        {
            var entity = new ProductEntity
            {
                Id = productItem.Id,
                Name = productItem.Name,
                CategoryId = productItem.CategoryId,
                Description = productItem.Description
            };
            await _productsRepository.Update(entity);
        }
    }
}
