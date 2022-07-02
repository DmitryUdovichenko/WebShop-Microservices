namespace Catalog.API.Repositories
{
    public interface ICatalogItemRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetByName(string name);
        Task<T> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(string id);
        
    }
}
