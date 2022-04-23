namespace ProductsImporter.Commands.ImportProducts;

using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Miscellaneous.Enums;
using ProductsImporter.Services;

[Command(Name = "software-advice", Description = "Import products from software-advice")]
public class SoftwareAdviceImportCmd
{
    [Argument(0)] 
    [Required]
    [LegalFilePath] 
    public string Filepath { get; set; }
    
    private readonly IProductsImportService _productsImportService;
    
    public SoftwareAdviceImportCmd(IProductsImportService productsImportService)
    {
        _productsImportService = productsImportService;
    }
    
    public async Task OnExecuteAsync(CommandLineApplication app)
    {
        await _productsImportService.ImportProductsFromProvider(Filepath, DataProvider.SoftwareAdvice);
    }
}