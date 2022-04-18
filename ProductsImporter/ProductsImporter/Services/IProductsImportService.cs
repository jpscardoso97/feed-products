namespace ProductsImporter.Services;

using Miscellaneous.Enums;

public interface IProductsImportService
{
    Task ImportProducts(string filepath, DataProvider dataProvider);
    
    Task ImportProducts(string filepath);
}