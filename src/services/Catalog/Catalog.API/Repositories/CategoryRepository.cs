using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICatalogContext _context;

        public CategoryRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category item)
        {
            await _context.Categories.InsertOneAsync(item);
            return item;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(c => c.Id, id);

            DeleteResult result = await _context.Categories.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.Find(p => true).ToListAsync();
        }

        public async Task<Category> GetById(string id)
        {
            return await _context.Categories.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(c => c.Name, name);

            return await _context.Categories.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Category item)
        {
            var result = await _context.Categories
                .ReplaceOneAsync(filter: c => c.Id == item.Id, replacement: item);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
