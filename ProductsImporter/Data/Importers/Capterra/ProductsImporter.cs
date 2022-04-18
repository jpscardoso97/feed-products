namespace Data.Importers.Capterra;

using Data.Importers.Capterra.Mappers;
using Data.Importers.Capterra.Parser;
using Data.Importers.Interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using ProductDto = Data.Dto.Product;

public class ProductsImporter : IProductsImporter
{
    public async Task<IEnumerable<ProductDto>> Import(string source)
    {
        /*IEnumerable<Product> capterraProducts = new List<Product>()
        {
            new() { Name = "Github", Categories = new[] { "Bugs & Issue Tracking", "Development Tools" } },
            new() { Name = "Slack", Categories = new[] { "Instant Messaging & Chat", "Web Collaboration", "Productivity" } },
            new() { Name = "JIRA Software", Categories = new[] { "Project Management", "Project Collaboration", "Development Tools" } }
        };*/
        if (!source.EndsWith(".yaml") && !source.EndsWith(".yml"))
        {
            throw new Exception("Not a valid JSON file");
        }

        var yamlString = await File.ReadAllTextAsync(source);

        var deserializer = new DeserializerBuilder().WithNamingConvention(LowerCaseNamingConvention.Instance).Build();
        var products = deserializer.Deserialize<IEnumerable<Product>>(yamlString);

        return products?.Select(p => p.Map());
    }
}