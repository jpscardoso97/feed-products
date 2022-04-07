namespace ProductsImporter.Services;

using System.Text;
using Data.Dto;
using Data.Factory;
using Microsoft.Extensions.Hosting;

public class ProductsImportService : IHostedService, IDisposable
{
    private readonly IProductsProvidersFactory _productsProvidersFactory;
    
    private Timer _timer = null!;
    
    public ProductsImportService(IProductsProvidersFactory productsProvidersFactory)
    {
        _productsProvidersFactory = productsProvidersFactory;
    }

    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(StartImport, null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(15));
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    public void StartImport(object state)
    {
        _ = this.ImportProducts();
    }

    public async Task ImportProducts()
    {
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
}