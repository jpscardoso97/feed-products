using System.Linq;
using Data.Importers.SoftwareAdvice.Mappers;
using Data.Importers.SoftwareAdvice.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests.Importers.SoftwareAdvice.Mappers;

[TestClass]
public class ProductMapperTests
{
    [TestMethod]
    public void Map_ValidProduct_ReturnsExpectedProductDto()
    {
        // Arrange
        var product = new Product{ Title = "Github", Categories = new[] { "Customer Service", "Call Center" } };

        // Act
        var result = product.Map();
        
        // Assert
        Assert.AreEqual(product.Title, result.Name);
        Assert.AreEqual(2, result.Categories.Count());
        Assert.AreEqual(product.Categories.ElementAt(0), result.Categories.ElementAt(0));
        Assert.AreEqual(product.Categories.ElementAt(1), result.Categories.ElementAt(1));
    }
}