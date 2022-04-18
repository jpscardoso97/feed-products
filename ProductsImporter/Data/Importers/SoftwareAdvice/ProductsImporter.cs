namespace Data.Importers.SoftwareAdvice;

using System.Text.Json;
using Data.Importers.Interfaces;
using Data.Importers.SoftwareAdvice.Mappers;
using Data.Importers.SoftwareAdvice.Parser;
using ProductDto = Data.Dto.Product;

public class ProductsImporter : IProductsImporter
{
    public async Task<IEnumerable<ProductDto>> Import(string source)
    {
        /*IEnumerable<Product> softwareAdviceProducts = new List<Product>()
        {
            new() { Name = "Freshdesk", Categories = new[] { "Customer Service", "Call Center" } },
            new() { Name = "Zoho", Categories = new[] { "CRM", "Sales Management" } }
        };*/
        
        try
        {
            if (!source.EndsWith(".json"))
            {
                throw new Exception("Not a valid JSON file");
            }
            
            using (FileStream  file = File.OpenRead(source))
            {
                var result = await JsonSerializer.DeserializeAsync<Response>(file);

                return result?.Products?.Select(p => p.Map());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}