using CatalogServiceAPI.Models;
using CatalogServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController(IItemService itemService) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetItems([FromQuery] int categoryId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(itemService.GetItems(categoryId, page, pageSize));
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ItemRequest createItem)
        {
            var item = itemService.CreateItem(createItem);
            if (item == null) return NotFound();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = itemService.GetItem(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] ItemRequest updateItem)
        {
            var item = itemService.UpdateItem(id, updateItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var IsDeleted = itemService.DeleteItem(id);
            if (!IsDeleted) return NotFound();
            return NoContent();
        }
    }
}
