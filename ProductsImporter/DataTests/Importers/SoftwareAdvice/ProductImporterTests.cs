using System;
using System.Threading.Tasks;
using Data.Importers.SoftwareAdvice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqMeUp;

namespace DataTests.Importers.SoftwareAdvice;

[TestClass]
public class ProductImporterTests : MoqMeUp<ProductsImporter>
{
    [TestMethod]
    public async Task Import_NotValidSourceType_ThrowsException()
    {
        // Act & Assert
        await Assert.ThrowsExceptionAsync<Exception>(() => this.Build().ImportAsync("source.yaml"), "Not a valid JSON file");
    }
}