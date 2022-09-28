namespace Catalog.API.Entities;

public class DbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string ProductsCollectionName { get; set; }
    public string CategoriesCollectionName { get; set; }
    
}