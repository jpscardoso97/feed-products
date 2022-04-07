namespace Data.Repository.Interfaces;

using Data.Dto;

public interface IProductsRepository
{
    Task<Product> SaveAsync(Product product);
    
    Task<IEnumerable<Product>> SaveAsync(IEnumerable<Product> products);
    
    Task<Product> GetByIdAsync(string productId);
    
    Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<string> productIds);
    
    Task<IEnumerable<Product>> GetAsync();
    
    Task<IEnumerable<Product>> GetByCategoryAsync(string categoryId);
}