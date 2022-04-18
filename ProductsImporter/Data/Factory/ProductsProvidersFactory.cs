﻿namespace Data.Factory;

using Data.Importers.Interfaces;
using Miscellaneous.Enums;
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

    public IProductsImporter GetProvider(DataProvider provider)
    {
        switch (provider)
        {
            case DataProvider.Capterra:
                return _capterraImporter;
            case DataProvider.SoftwareAdvice:
                return _softwareAdviceImporter;
            default:
                throw new NotSupportedException("No compatible provider was found");
        }
    }

    public IEnumerable<IProductsImporter> GetProviders()
    {
        return new[] { _capterraImporter, _softwareAdviceImporter };
    }
}