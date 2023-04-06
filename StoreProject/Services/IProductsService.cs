using StoreProject.Api.Models;

namespace StoreProject.Api.Services
{
    public interface IProductsService //Можно не объявлять методы паблик, так как по дефолту
    {
        IEnumerable<ProductItem> GetProducts();
    }
}
