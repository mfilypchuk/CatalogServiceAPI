using CatalogServiceAPI.Models;
using CatalogServiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(categoryService.GetCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryRequest createCategory)
        {
            var category = categoryService.CreateCategory(createCategory);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryRequest updateCategory)
        {
            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            categoryService.UpdateCategory(category, updateCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            categoryService.DeleteCategory(category);
            return NoContent();
        }
    }
}
