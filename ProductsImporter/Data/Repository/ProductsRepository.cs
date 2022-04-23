namespace Data.Repository;

using System.Text;
using Data.Dto;
using Data.Repository.Interfaces;

public class ProductsRepository : IProductsRepository
{
    public Task<Product> SaveAsync(Product product)
    {
        PrintToConsole(product);
        
        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> SaveAsync(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            PrintToConsole(product);
        }
        
        
        return Task.FromResult(products);
    }

    public Task<Product> GetByIdAsync(string productId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<string> productIds)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(string categoryId)
    {
        throw new NotImplementedException();
    }

    private static void PrintToConsole(Product product)
    {
        Console.Out.WriteLine("\nImporting Product:");
        var categories = new StringBuilder();
        
        foreach (var c in  product.Categories)
        {
            categories.Append($"{c}, ");
        }
        
        Console.Out.WriteLine($"Name: {product.Name}; Categories: {categories}");
    }
    
}