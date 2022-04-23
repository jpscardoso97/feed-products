namespace ProductsImporter.Services;

using Miscellaneous.Enums;

public interface IProductsImportService
{
    Task ImportProductsFromProvider(string source, DataProvider dataProvider);
    
    Task ImportProducts(string source);
}