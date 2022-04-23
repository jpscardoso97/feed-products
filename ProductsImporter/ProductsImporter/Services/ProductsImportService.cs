namespace ProductsImporter.Services;

using System.Text;
using Data.Dto;
using Data.Factory;
using Data.Repository.Interfaces;
using Miscellaneous.Enums;

public class ProductsImportService : IProductsImportService
{
    private readonly IProductsProvidersFactory _productsProvidersFactory;
    private readonly IProductsRepository _productsRepository;
    
    public ProductsImportService(
        IProductsProvidersFactory productsProvidersFactory, 
        IProductsRepository productsRepository)
    {
        _productsProvidersFactory = productsProvidersFactory;
        _productsRepository = productsRepository;
    }

    public async Task ImportProductsFromProvider(string source, DataProvider dataProvider)
    {
        if (!ValidateInput(source))
        {
            return;
        }

        try
        {
            var provider = _productsProvidersFactory.GetProvider(dataProvider);
            var importedProducts = await provider.Import(source);

            if (importedProducts != null)
            {
                await _productsRepository.SaveAsync(importedProducts);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    public async Task ImportProducts(string source)
    {
        if (!ValidateInput(source))
        {
            return;
        }

        try
        {
            var providers = _productsProvidersFactory.GetProviders();
            
            var providerImportTasks = new List<Task<IEnumerable<Product>>>();

            foreach (var provider in providers)
            {
                providerImportTasks.Add(provider.Import(source));
            }
        
            await Task.WhenAll(providerImportTasks);

            foreach (var providerImportTask in providerImportTasks)
            {
                var providerProducts = await providerImportTask;
                await _productsRepository.SaveAsync(providerProducts);
            }

            Console.Out.WriteLine("-------------------------------------------------------");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static bool ValidateInput(string source)
    {
        if (!string.IsNullOrWhiteSpace(source)) 
            return true;
        
        Console.Out.WriteLine("Invalid source provided");
            
        return false;

    }
}