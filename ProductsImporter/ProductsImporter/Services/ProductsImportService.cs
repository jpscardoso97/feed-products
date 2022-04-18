namespace ProductsImporter.Services;

using System.Text;
using Data.Dto;
using Data.Factory;
using Miscellaneous.Enums;

public class ProductsImportService : IProductsImportService
{
    private readonly IProductsProvidersFactory _productsProvidersFactory;
    
    public ProductsImportService(IProductsProvidersFactory productsProvidersFactory)
    {
        _productsProvidersFactory = productsProvidersFactory;
    }

    public async Task ImportProducts(string filepath, DataProvider dataProvider)
    {
        ValidateInput(filepath);
        var provider = _productsProvidersFactory.GetProvider(dataProvider);
        var importedProducts = await provider.Import();

        foreach (var product in importedProducts)
        {
            PrintToConsole(product);
        }
    }
    
    public async Task ImportProducts(string filepath)
    {
        ValidateInput(filepath);
        
        var providers = _productsProvidersFactory.GetProviders();
        var providerImportTasks = new List<Task<IEnumerable<Product>>>();

        foreach (var provider in providers)
        {
            providerImportTasks.Add(provider.Import());
        }
        
        await Task.WhenAll(providerImportTasks);

        foreach (var providerImportTask in providerImportTasks)
        {
            var providerProducts = await providerImportTask;
            foreach (var product in providerProducts)
            {
                PrintToConsole(product);
            }
        }

        Console.Out.WriteLine("-------------------------------------------------------");
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

    private static void ValidateInput(string filepath)
    {
        if (string.IsNullOrWhiteSpace(filepath))
        {
            Console.Out.WriteLine("Invalid source provided");
        }
    }
}