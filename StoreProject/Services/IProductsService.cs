using StoreProject.Api.Models;

namespace StoreProject.Api.Services
{
    public interface IProductsService //Можно не объявлять методы паблик, так как по дефолту
    {
        Task<IEnumerable<ProductItem>> GetProducts();
        Task<ProductItem?> GetProductById(Guid productId);
        Task AddProduct(ProductItem productItem);
        Task DeleteProduct(Guid id);
        Task UpdateProduct(ProductItem productItem);
    }
}
