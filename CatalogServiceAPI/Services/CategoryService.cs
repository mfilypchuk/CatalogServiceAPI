using CatalogServiceAPI.DataAccess;
using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.Services
{
    public class CategoryService(CatalogContext context) : ICategoryService
    {

        public List<Category> GetCategories()
        {
            return context.Categories;
        }

        public Category GetCategoryById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category CreateCategory(CategoryRequest createCategory) 
        {
            var category = new Category
            {
                Id = context.Categories.Max(x => x.Id) + 1,
                Name = createCategory.Name,
            };

            context.Categories.Add(category);
            return category;
        }

        public void UpdateCategory(Category category, CategoryRequest updateCategory)
        {
            category.Name = updateCategory.Name;
        }

        public void DeleteCategory(Category category) 
        {
            context.Categories.Remove(category);
        }
    }
}
