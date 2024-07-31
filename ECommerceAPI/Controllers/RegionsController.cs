using Business.Abstract;
using Core.Helper.Result.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Region region)
        {
            var result = _regionService.Add(region);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _regionService.Delete(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(int id, Region region)
        {
            var result = _regionService.Update(id, region);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _regionService.GetRegion(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _regionService.GetAllRegions();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}

