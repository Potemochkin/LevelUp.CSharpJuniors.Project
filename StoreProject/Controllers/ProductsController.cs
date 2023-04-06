using Microsoft.AspNetCore.Mvc;
using StoreProject.Api.Models;
using StoreProject.Api.Services;

namespace StoreProject.Api.Controllers
{
    [ApiController]
    [Route("api /[controller]")]
    public sealed class ProductsController : ControllerBase
    {

        private IProductsService _productsService;

        public ProductsController(IProductsService productsService) 
        {
            _productsService = productsService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<ProductItem>> GetProducts()
        {
            var products = _productsService.GetProducts();
            return Ok(products);
        }

    }   
}
