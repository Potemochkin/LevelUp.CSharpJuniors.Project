using StoreProject.Api.Models;

namespace StoreProject.Api.Services
{
    public sealed class ProductsService : IProductsService
    {

        private Dictionary<Guid, ProductItem> _products = new();

        public ProductsService() 
        {
            InitProducts();
        }
        public IEnumerable<ProductItem> GetProducts()
        {
            return _products.Values;
        }

        private void InitProducts() 
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();

            _products = new Dictionary<Guid, ProductItem>
            {
                {guid1, new ProductItem(guid1, "Печенье", "Сдобное") },
                {guid2, new ProductItem(guid2, "Шоколадка", "Черный") },
                {guid3, new ProductItem(guid3, "Мороженое", "Клубничное") }
            };
        }
    }
}
