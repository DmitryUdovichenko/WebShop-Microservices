using Catalog.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private MongoClient _client;
        private readonly IMongoDatabase _context;

        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<Category> Categories { get; }

        public CatalogContext(IOptions<DbSettings> dbSettings)
        {
            var dbSettingsValue = dbSettings.Value;
            _client = new MongoClient( dbSettingsValue.ConnectionString );
            _context = _client.GetDatabase( dbSettingsValue.DatabaseName );
            Products = _context.GetCollection<Product>( dbSettingsValue.ProductsCollectionName );
            Categories = _context.GetCollection<Category>( dbSettingsValue.CategoriesCollectionName );
            CatalogContextSeed.SeedData(Products, Categories);

        }

    }
}
