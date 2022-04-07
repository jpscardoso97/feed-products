namespace Data.Factory;

using Data.Importers.Interfaces;

public interface IProductsProvidersFactory
{
    IEnumerable<IProductsImporter> GetProviders();
}