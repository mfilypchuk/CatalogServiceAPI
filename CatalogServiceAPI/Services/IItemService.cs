using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.Services
{
    public interface IItemService
    {
        List<Item> GetItems(int categoryId, int page, int pageSize);
        Item? GetItem(int categoryId, int id);
        Item? CreateItem(int categoryId, ItemRequest item);
        Item? UpdateItem(int categoryId, int id, ItemRequest updateItem);
        bool DeleteItem(int categoryId, int id);
    }
}
