namespace Data.Importers.Capterra;

using Data.Dto;
using Data.Importers.Interfaces;

public class ProductsImporter : IProductsImporter
{
    public Task<IEnumerable<Product>> Import()
    {
        IEnumerable<Product> capterraProducts = new List<Product>()
        {
            new() { Name = "Github", Categories = new[] { "Bugs & Issue Tracking", "Development Tools" } },
            new() { Name = "Slack", Categories = new[] { "Instant Messaging & Chat", "Web Collaboration", "Productivity" } },
            new() { Name = "JIRA Software", Categories = new[] { "Project Management", "Project Collaboration", "Development Tools" } }
        };

        return Task.FromResult(capterraProducts);
    }
}