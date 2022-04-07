namespace ProductsImporter;

using Data.Factory;
using Data.Repository;
using Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsImporter.Services;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services
                    .AddSingleton<IProductsProvidersFactory, ProductsProvidersFactory>()
                    .AddSingleton<IProductsRepository, ProductsRepository>()
                    .AddHostedService<ProductsImportService>());
}