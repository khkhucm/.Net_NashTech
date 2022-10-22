using Assignment02.DTOs.Product;
using Assignment02.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public AddProductResponse? Add([FromBody] AddProductRequest addModel)
        {
            return _productService.Add(addModel);
        }

        [HttpGet]
        public IEnumerable<ProductViewModel>? GetAll()
        {
            try
            {
                var products = _productService.GetAll();

                return products;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        public ProductViewModel? Get(int id)
        {
            try
            {
                var product = _productService.GetById(id);

                return product;
            }
            catch
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public UpdateProductResponse Update(int id, [FromBody] UpdateProductRequest updateModel)
        {
            try
            {
                var updatedProduct = _productService.Update(id, updateModel);

                return updatedProduct!;
            }
            catch
            {
                return null!;
            }
        }

        [HttpDelete("{id}")]
        public ProductViewModel Delete(int id)
        {
            try
            {
                var deletedProduct = _productService.Delete(id);

                return deletedProduct!;
            }
            catch
            {
                return null!;
            }
        }

    }
}