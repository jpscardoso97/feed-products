using System;
using System.Threading.Tasks;
using Data.Importers.Capterra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqMeUp;

namespace DataTests.Importers.Capterra;

[TestClass]
public class ProductImporterTests : MoqMeUp<ProductsImporter>
{
    [TestMethod]
    public async Task Import_NotValidSourceType_ThrowsException()
    {
        // Act & Assert
        await Assert.ThrowsExceptionAsync<Exception>(() => this.Build().ImportAsync("source.json"), "Not a valid YAML file");
    }
}