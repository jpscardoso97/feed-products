namespace Data.Importers.Capterra;

using Data.Importers.Capterra.Mappers;
using Data.Importers.Capterra.Parser;
using Data.Importers.Interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using ProductDto = Data.Dto.Product;

public class ProductsImporter : IProductsImporter
{
    public async Task<IEnumerable<ProductDto>> ImportAsync(string source)
    {
        if (!source.EndsWith(".yaml") && !source.EndsWith(".yml"))
        {
            throw new Exception("Not a valid YAML file");
        }

        if (!File.Exists(source))
        {
            throw new Exception("Source file doesn't exist");
        }
        
        var yamlString = await File.ReadAllTextAsync(source);

        var deserializer = new DeserializerBuilder().WithNamingConvention(LowerCaseNamingConvention.Instance).Build();
        var products = deserializer.Deserialize<IEnumerable<Product>>(yamlString);

        return products?.Select(p => p.Map());
    }
}