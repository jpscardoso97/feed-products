namespace ProductsImporter.Services;

using Miscellaneous.Enums;

public interface IProductsImportService
{
    Task ImportProducts(string source, DataProvider dataProvider);
    
    Task ImportProducts(string source);
}