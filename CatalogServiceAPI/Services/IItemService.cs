using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.Services
{
    public interface IItemService
    {
        List<Item> GetItems(int categoryId, int page, int pageSize);
        Item? GetItem(int id);
        Item? CreateItem(ItemRequest item);
        Item? UpdateItem(int id, ItemRequest updateItem);
        bool DeleteItem(int id);
    }
}
