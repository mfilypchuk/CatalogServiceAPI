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

        public Item? GetItem(int categoryId, int itemId)
        {
            var category = context.Categories
                .FirstOrDefault(c => c.Id == categoryId);

            return category?.Items.FirstOrDefault(i => i.Id == itemId);
        }

        public Item? CreateItem(int categoryId, ItemRequest item)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
            if (category == null)
            {
                return null;
            }
            var nextId = category.Items.Max(x => x.Id);
            var newItem = new Item { CategoryId = categoryId, Name = item.Name, Id = nextId };
            category.Items.Add(newItem);
            return newItem;
        }

        public Item? UpdateItem(int categoryId, int id, ItemRequest updateItem)
        {
            var item = GetItem(categoryId, id);
            if (item == null) 
            { 
                return null;
            }
            item.Name = updateItem.Name;
            return item;
        }

        public bool DeleteItem(int categoryId, int id)
        {
            var item = GetItem(categoryId, id);
            if (item == null)
            {
                return false;
            }
            var category = context.Categories.First(c => c.Id == categoryId);
            category.Items.Remove(item);
            return true;
        }
    }
}
