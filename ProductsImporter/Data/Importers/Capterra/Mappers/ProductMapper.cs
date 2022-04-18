namespace Data.Importers.Capterra.Mappers;

using Data.Importers.Capterra.Parser;
using ProductDto = Data.Dto.Product;

public static class ProductMapper
{
    public static ProductDto Map(this Product product)
    {
        return new ProductDto
        {
            Name = product.Name,
            Categories = MapTagsToCategories(product.Tags)
        };
    }

    private static IEnumerable<string> MapTagsToCategories(string productTags) =>
        productTags?.Split(',').Select(tag => tag.Trim());
}