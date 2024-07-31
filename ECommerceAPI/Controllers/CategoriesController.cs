using Business.Abstract;
using Core.Helper.Result.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Category category)
        { 
            var result = _categoryService.Add(category);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        { 
            var result = _categoryService.Delete(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("Get")]
        public IActionResult Get(int id) 
        {
            var result = _categoryService.GetCategory(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        { 
            var result = _categoryService.GetAllCategories();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
