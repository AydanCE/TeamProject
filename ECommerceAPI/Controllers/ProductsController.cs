using Business.Abstract;
using Core.Helper.Result.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        { 
            var result = _productService.Add(product);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        { 
            var result = _productService.Delete(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(int id, Product product)
        {
            var result = _productService.Update(id, product);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("Get")]
        public IActionResult Get(int id) 
        {
            var result = _productService.GetProduct(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        { 
            var result = _productService.GetAllProducts();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
