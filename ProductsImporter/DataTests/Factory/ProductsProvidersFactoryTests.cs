namespace DataTests.Factory;

using Data.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miscellaneous.Enums;
using MoqMeUp;
using SoftwareAdviceProductsImporter = Data.Importers.SoftwareAdvice.ProductsImporter;
using CapterraProductsImporter = Data.Importers.Capterra.ProductsImporter;

[TestClass]
public class ProductsProvidersFactoryTests : MoqMeUp<ProductsProvidersFactory>
{
    [TestMethod]
    public void GetProvider_CapterraProvider_ReturnsImporter()
    {
        // Arrange & Act
        var result = this.Build().GetProvider(DataProvider.Capterra);

        Assert.IsTrue(result is CapterraProductsImporter);
    }

    [TestMethod]
    public void GetProvider_SoftwareAdviceProvider_ReturnsImporter()
    {
        // Arrange & Act
        var result = this.Build().GetProvider(DataProvider.SoftwareAdvice);

        Assert.IsTrue(result is SoftwareAdviceProductsImporter);
    }
}