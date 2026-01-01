using CatalogServiceAPI.Models;
using CatalogServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}items")]
    public class ItemController(IItemService itemService) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetItems(int categoryId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(itemService.GetItems(categoryId, page, pageSize));
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(int categoryId, int itemId)
        {
            var item = itemService.GetItem(categoryId, itemId);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult AddItem(int categoryId, [FromBody] ItemRequest createItem)
        {
            var item = itemService.CreateItem(categoryId, createItem);
            if (item == null) return NotFound();
            return CreatedAtAction(nameof(GetItem), new { categoryId, itemId = item.Id }, item);
        }

        [HttpPut("{itemId}")]
        public IActionResult UpdateItem(int categoryId, int itemId, [FromBody] ItemRequest updateItem)
        {
            var item = itemService.UpdateItem(categoryId, itemId, updateItem);
            if (item == null || item.CategoryId != categoryId) return NotFound();
            return NoContent();
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(int categoryId, int itemId)
        {
            var isDeleted = itemService.DeleteItem(categoryId, itemId);
            if (!isDeleted) return NotFound();
            return NoContent();
        }
    }
}
