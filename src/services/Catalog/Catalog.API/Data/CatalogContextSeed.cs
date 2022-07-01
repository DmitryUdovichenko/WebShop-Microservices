using Catalog.API.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        private static IMongoCollection<Category> _categoryCollection;
        private static IMongoCollection<Product> _productCollection;

        public static void SeedData(IMongoCollection<Product> productCollection, IMongoCollection<Category> categoryCollection)
        {
            _categoryCollection = categoryCollection;
            bool existCategories = _categoryCollection.Find(c => true).Any();
            if (!existCategories)
            {
                _categoryCollection.InsertManyAsync(GetPreconfiguredCategoriesCollection());
            }

            _productCollection = productCollection;
            bool existProducts = _productCollection.Find(c => true).Any();
            if (!existProducts)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProductsCollection());
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategoriesCollection()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Name = "Category 1",                    
                    ImageFile = "product-1.png",
                },
                new Category()
                {
                    Name = "Category 2",
                    ImageFile = "product-1.png",
                },
                new Category()
                {
                    Name = "Category 3",
                    ImageFile = "product-1.png",
                },

            };
        }

        private static IEnumerable<Product> GetPreconfiguredProductsCollection()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    CategoryId = _categoryCollection.AsQueryable().Sample(1).First().Id
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    CategoryId = _categoryCollection.AsQueryable().Sample(1).First().Id
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    CategoryId = _categoryCollection.AsQueryable().Sample(1).First().Id
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    CategoryId = _categoryCollection.AsQueryable().Sample(1).First().Id
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    CategoryId = _categoryCollection.AsQueryable().Sample(1).First().Id
                },
                new Product()
                {
                    Name = "LG G7 ThinQ",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    CategoryId = _categoryCollection.AsQueryable().Sample(1).First().Id
                }
            };

        }
    }
}
