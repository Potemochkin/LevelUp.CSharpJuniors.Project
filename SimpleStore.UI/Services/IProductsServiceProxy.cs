using SimpleStore.UI.Model;

namespace SimpleStore.UI.Services
{
    public interface IProductsServiceProxy
    {
        Task<IEnumerable<ProductItem>> GetAllProducts();

        Task<ProductItem> GetProductById(Guid id);

    }
}
