using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        Category CreateCategory(CategoryRequest createCategory);
        void UpdateCategory(Category category, CategoryRequest updateCategory);
        void DeleteCategory(Category category);
    }
}
