using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private MongoClient _client;
        private readonly IMongoDatabase _context;

        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<Category> Categories { get; }

        public CatalogContext(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            _context = _client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = _context.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ProductsCollectionName"));
            Categories = _context.GetCollection<Category>(configuration.GetValue<string>("DatabaseSettings:CategoriesCollectionName"));

        }

    }
}
