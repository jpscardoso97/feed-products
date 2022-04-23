namespace Data.Importers.SoftwareAdvice;

using System.Text.Json;
using Data.Importers.Interfaces;
using Data.Importers.SoftwareAdvice.Mappers;
using Data.Importers.SoftwareAdvice.Parser;
using ProductDto = Data.Dto.Product;

public class ProductsImporter : IProductsImporter
{
    public async Task<IEnumerable<ProductDto>> ImportAsync(string source)
    {
        try
        {
            if (!source.EndsWith(".json"))
            {
                throw new Exception("Not a valid JSON file");
            }
            
            if (!File.Exists(source))
            {
                throw new Exception("Source file doesn't exist");
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