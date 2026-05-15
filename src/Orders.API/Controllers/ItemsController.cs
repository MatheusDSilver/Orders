using Microsoft.AspNetCore.Mvc;
using Orders.Application.InputModels;
using Orders.Application.Services;
using Orders.Domain.Repositories;

namespace Orders.API.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemsController(IItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemInputModel model)
        {
            var itemName = await _service.Add(model);

            return CreatedAtAction(
                nameof(GetByName),
                new {itemName },
                itemName
                );
        }
        [HttpGet("{itemName}")]
        public async Task<IActionResult> GetByName(string itemName)
        {
            var item = await _service.GetByName(itemName);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
