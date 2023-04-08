using Microsoft.AspNetCore.Mvc;
using StoreProject.Api.Models;
using StoreProject.Api.Services;

namespace StoreProject.Api.Controllers // Точка входа в приложение - контролле. То, что подхватывает запрос из внешнего мира
{
    [ApiController]
    [Route("/[controller]")]
    public sealed class ProductsController : ControllerBase
    {

        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService) 
        {
            _productsService = productsService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProducts() // Дальше контроллер подхватывает бизнес-логику
        {
            var products = await _productsService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductItem>> GetByID([FromRoute]Guid productId)
        {
            //вызываем сервис
            var product = await _productsService.GetProductById(productId); 
            return product == null ? NotFound() : Ok(product); // Проверяем что вернули из product service (item)
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductItem productItem)
        {
           await _productsService.AddProduct(productItem);
           return Ok();
        }

        [HttpDelete("del")]
        public async Task<IActionResult> DelProduct(Guid id)
        {
            await _productsService.DeleteProduct(id);
            return Ok();
        }

        [HttpPut("upd")]
        public async Task<IActionResult> UpdateProduct(ProductItem productItem)
        {
            await _productsService.UpdateProduct(productItem);
            return Ok();
        }
    }   
}
