namespace Data.Factory;

using Data.Importers.Interfaces;

using SoftwareAdviceProductsImporter = Importers.SoftwareAdvice.ProductsImporter;
using CapterraProductsImporter = Importers.Capterra.ProductsImporter;

public class ProductsProvidersFactory : IProductsProvidersFactory
{
    private readonly IProductsImporter _capterraImporter;
    private readonly IProductsImporter _softwareAdviceImporter;

    public ProductsProvidersFactory()
    {
        _capterraImporter = new CapterraProductsImporter();
        _softwareAdviceImporter = new SoftwareAdviceProductsImporter();
    }

    public IEnumerable<IProductsImporter> GetProviders()
    {
        return new[] { _capterraImporter, _softwareAdviceImporter };
    }
}