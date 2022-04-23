namespace ProductsImporterTests.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Dto;
using Data.Factory;
using Data.Importers.Interfaces;
using Data.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miscellaneous.Enums;
using Moq;
using MoqMeUp;
using ProductsImporter.Services;
using Xunit;

[TestClass]
public class ProductsImportServiceTests : MoqMeUp<ProductsImportService>
{
    private const string DummyPath = "path";
    
    private Mock<IProductsProvidersFactory> _productsProvidersFactoryMock;
    private Mock<IProductsRepository> _productsRepositoryMock;
    private Mock<IProductsImporter> _importerMock;

    private readonly IEnumerable<Product> DummyProducts = new List<Product>
    {
        new() {Name = "Freshdesk", Categories = new[] {"Customer Service", "Call Center"}},
        new() {Name = "Zoho", Categories = new[] {"CRM", "Sales Management"}}
    };

    public ProductsImportServiceTests()
    {
        _importerMock = new Mock<IProductsImporter>();
        _importerMock
            .Setup(i => i.ImportAsync(It.IsAny<string>()))
            .ReturnsAsync(new List<Product>()
            {
                new() { Name = "Freshdesk", Categories = new[] { "Customer Service", "Call Center" } },
                new() { Name = "Zoho", Categories = new[] { "CRM", "Sales Management" } }
            });

        _productsProvidersFactoryMock = this.Get<IProductsProvidersFactory>();
        _productsProvidersFactoryMock
            .Setup(ppf => ppf.GetProviders())
            .Returns(new List<IProductsImporter>()
            {
                _importerMock.Object,
                _importerMock.Object
            });

        _productsProvidersFactoryMock
            .Setup(ppf => ppf.GetProvider(It.IsAny<DataProvider>()))
            .Returns(_importerMock.Object);

        _productsRepositoryMock = this.Get<IProductsRepository>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task ImportProducts_InvalidSource_DoesNotExecuteImport(string source)
    {
        // Act
        await this.Build().ImportProducts(source);

        // Assert
        _productsProvidersFactoryMock.VerifyNoOtherCalls();
        _importerMock.VerifyNoOtherCalls();
        _productsRepositoryMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task ImportProducts_ProductsProviderFactoryReturnsProviders_ExecutesImportForEveryProvider()
    {
        // Act
        await this.Build().ImportProducts(DummyPath);

        // Assert
        _productsRepositoryMock.Verify(r => r.SaveAsync(It.IsAny<IEnumerable<Product>>()), Times.Exactly(2));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task ImportProductsFromProvider_InvalidSource_DoesNotExecuteImport(string source)
    {
        // Act
        await this.Build().ImportProductsFromProvider(source, It.IsAny<DataProvider>());

        // Assert
        _productsProvidersFactoryMock.VerifyNoOtherCalls();
        _importerMock.VerifyNoOtherCalls();
        _productsRepositoryMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task ImportProductsFromProvider_ProductsProviderFactoryThrowsException_ExecutesImportForEveryProvider()
    {
        // Arrange
        _productsProvidersFactoryMock
            .Setup(ppf => ppf.GetProvider(It.IsAny<DataProvider>()))
            .Throws(new NotSupportedException());

        // Act
        await this.Build().ImportProductsFromProvider(DummyPath, It.IsAny<DataProvider>());

        // Assert
        _importerMock.VerifyNoOtherCalls();
        _productsRepositoryMock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public async Task ImportProductsFromProvider_ValidSourceProductsProviderFactoryReturnsProvider_ExecutesImport()
    {
        // Act
        await this.Build().ImportProductsFromProvider(DummyPath, It.IsAny<DataProvider>());

        // Assert
        _importerMock.Verify(r => r.ImportAsync(It.IsAny<string>()), Times.Once);
        
        _productsRepositoryMock.Verify(r =>
            r.SaveAsync(It.Is<IEnumerable<Product>>(l => l.Count() == DummyProducts.Count())), Times.Once);
    }
}