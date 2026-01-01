using CatalogServiceAPI.Models;

namespace CatalogServiceAPI.DataAccess
{
    public class CatalogContext
    {
        public List<Category> Categories { get; set; } = new();

        public CatalogContext()
        {
            SeedData();
        }

        public void SeedData()
        {
            Categories.AddRange(
            [
                new Category { Id = 1, Name = "Books", 
                    Items = 
                    [ 
                        new Item { Id = 1, Name = "C# Programming", CategoryId = 1 },
                        new Item { Id = 2, Name = "ASP.NET Core Guide", CategoryId = 1 },
                    ] 
                },
                new Category { Id = 2, Name = "Electronics",
                    Items =
                    [
                        new Item { Id = 3, Name = "Smartphone", CategoryId = 2 },
                        new Item { Id = 4, Name = "Laptop", CategoryId = 2 },
                    ]
                },
                new Category { Id = 3, Name = "Clothing",
                    Items =
                    [
                        new Item { Id = 5, Name = "T-shirt", CategoryId = 3 },
                        new Item { Id = 6, Name = "Jeans", CategoryId = 3 }
                    ]
                },
            ]);
        }
    }
}
