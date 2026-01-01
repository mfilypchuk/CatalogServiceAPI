using CatalogServiceAPI.DataAccess;
using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.Services
{
    public class ItemService(CatalogContext context) : IItemService
    {

        public List<Item> GetItems(int categoryId, int page, int pageSize) 
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
            if (category == null) 
            { 
                return [];
            }

            return category.Items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Item? GetItem(int id)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Items.Any(i => i.Id == id));

            return category?.Items.FirstOrDefault(i => i.Id == id);
        }

        public Item? CreateItem(ItemRequest item) 
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == item.CategoryId);
            if (category == null)
            {
                return null;
            }
            var nextId = category.Items.Max(x => x.Id);
            var newItem = new Item { CategoryId = item.CategoryId, Name = item.Name, Id = nextId };
            category.Items.Add(newItem);
            return newItem;
        }

        public Item? UpdateItem(int id, ItemRequest updateItem)
        {
            var item = context.Categories.SelectMany(c => c.Items).FirstOrDefault(i => i.Id == id);
            if (item == null) 
            { 
                return null;
            }
            item.Name = updateItem.Name;
            return item;
        }

        public bool DeleteItem(int id)
        {
            var item = context.Categories.SelectMany(c => c.Items).FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return false;
            }
            var category = context.Categories
                .FirstOrDefault(c => c.Items.Any(i => i.Id == id));
            category?.Items.Remove(item);
            return true;
        }
    }
}
