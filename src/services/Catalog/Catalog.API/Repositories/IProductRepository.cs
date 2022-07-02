using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository : ICatalogItemRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategory(string id);
    }
}
