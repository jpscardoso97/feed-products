namespace Data.Importers.SoftwareAdvice;

using Data.Dto;
using Data.Importers.Interfaces;

public class ProductsImporter : IProductsImporter
{
    public Task<IEnumerable<Product>> Import()
    {
        IEnumerable<Product> softwareAdviceProducts = new List<Product>()
        {
            new() { Name = "Freshdesk", Categories = new[] { "Customer Service", "Call Center" } },
            new() { Name = "Zoho", Categories = new[] { "CRM", "Sales Management" } }
        };

        return Task.FromResult(softwareAdviceProducts);
    }
}