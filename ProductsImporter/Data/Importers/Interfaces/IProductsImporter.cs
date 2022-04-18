namespace Data.Importers.Interfaces;

using Data.Dto;

public interface IProductsImporter
{
    Task<IEnumerable<Product>> Import(string source);
}