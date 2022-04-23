using System.Linq;
using Data.Importers.Capterra.Mappers;
using Data.Importers.Capterra.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests.Importers.Capterra.Mappers;

[TestClass]
public class ProductMapperTests
{
    /*IEnumerable<Product> capterraProducts = new List<Product>()
        {
            new() { Name = "Github", Categories = new[] { "Bugs & Issue Tracking", "Development Tools" } },
            new() { Name = "Slack", Categories = new[] { "Instant Messaging & Chat", "Web Collaboration", "Productivity" } },
            new() { Name = "JIRA Software", Categories = new[] { "Project Management", "Project Collaboration", "Development Tools" } }
        };*/

    [TestMethod]
    public void Map_ValidProduct_ReturnsExpectedProductDto()
    {
        // Arrange
        var product = new Product{ Name = "Github", Tags = "Bugs & Issue Tracking, Development Tools" };

        // Act
        var result = product.Map();
        
        // Assert
        Assert.AreEqual(product.Name, result.Name);
        Assert.AreEqual(2, result.Categories.Count());
        Assert.AreEqual("Bugs & Issue Tracking", result.Categories.ElementAt(0));
        Assert.AreEqual("Development Tools", result.Categories.ElementAt(1));
    }
}