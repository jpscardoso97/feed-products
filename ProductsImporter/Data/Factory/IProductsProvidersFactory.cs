namespace Data.Factory;

using Data.Importers.Interfaces;
using Miscellaneous.Enums;

public interface IProductsProvidersFactory
{
    IProductsImporter GetProvider(DataProvider provider);
    
    IEnumerable<IProductsImporter> GetProviders();
}