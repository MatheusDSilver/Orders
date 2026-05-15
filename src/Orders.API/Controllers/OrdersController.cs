using Microsoft.AspNetCore.Mvc;
using Orders.Application.InputModels;
using Orders.Application.Services;

namespace Orders.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var order = await _service.GetByCode(code);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderInputModel model)
        {
            var code = await _service.Add(model);
            return CreatedAtAction(
                nameof(GetByCode),
                new { code },
                code
                );
        }
    }
}
