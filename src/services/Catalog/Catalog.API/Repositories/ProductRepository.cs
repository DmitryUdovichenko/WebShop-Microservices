using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product item)
        {
            await _context.Products.InsertOneAsync(item);
            return item;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult result = await _context.Products.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, id);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Product item)
        {
            var result = await _context.Products
                .ReplaceOneAsync(filter: p => p.Id == item.Id, replacement: item);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
