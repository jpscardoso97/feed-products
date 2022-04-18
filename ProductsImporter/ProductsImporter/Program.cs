namespace ProductsImporter;

using Data.Factory;
using Data.Repository;
using Data.Repository.Interfaces;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsImporter.Services;

class Program
{
    public static async Task<int> Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        
        var app = new CommandLineApplication<BaseCmd>();
        app.Conventions
            .UseDefaultConventions()
            .UseConstructorInjection(host.Services);
        
        return await app.ExecuteAsync(args);
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services
                    .AddSingleton<IProductsProvidersFactory, ProductsProvidersFactory>()
                    .AddSingleton<IProductsRepository, ProductsRepository>()
                    .AddSingleton<IProductsImportService, ProductsImportService>());
}