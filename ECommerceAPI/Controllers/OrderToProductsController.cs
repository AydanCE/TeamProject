using Business.Abstract;
using Core.Helper.Result.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderToProductsController : ControllerBase
    {
        private readonly IOrderToProductService _connectionService;

        public OrderToProductsController(IOrderToProductService connectionService)
        {
            _connectionService = connectionService;
        }

        [HttpPost("Add")]
        public IActionResult Add(OrderDetail connection)
        {
            var result = _connectionService.Add(connection);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _connectionService.Delete(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(OrderDetail connection)
        {
            var result = _connectionService.Update(connection);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _connectionService.GetConnection(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _connectionService.GetAllConnections();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}

