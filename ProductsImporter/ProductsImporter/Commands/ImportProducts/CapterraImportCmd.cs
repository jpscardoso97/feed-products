﻿namespace ProductsImporter.Commands.ImportProducts;

using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using Miscellaneous.Enums;
using ProductsImporter.Services;

[Command(Name = "capterra", Description = "Import products from capterra")]
public class CapterraImportCmd
{
    [Argument(0)] 
    [Required]
    [LegalFilePath] 
    public string Filepath { get; set; }
    
    private readonly IProductsImportService _productsImportService;
    
    public CapterraImportCmd(IProductsImportService productsImportService)
    {
        _productsImportService = productsImportService;
    }
    
    public async Task OnExecuteAsync(CommandLineApplication app)
    {
        try
        {
            await _productsImportService.ImportProductsFromProvider(Filepath, DataProvider.Capterra);
        }
        catch (Exception e)
        {
            app.Error.WriteLine(e.Message);
        }
    }
}