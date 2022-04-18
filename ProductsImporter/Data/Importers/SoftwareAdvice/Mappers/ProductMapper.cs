namespace Data.Importers.SoftwareAdvice.Mappers;

using Data.Importers.SoftwareAdvice.Parser;
using ProductDto = Data.Dto.Product;

public static class ProductMapper
{
    public static ProductDto Map(this Product product)
    {
        return new ProductDto
        {
            Name = product.Title,
            Categories = product.Categories
        };
    }
}