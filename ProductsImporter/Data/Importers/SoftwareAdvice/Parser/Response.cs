namespace Data.Importers.SoftwareAdvice.Parser;

using System.Text.Json.Serialization;

public class Response
{
    [JsonPropertyName("products")]
    public IEnumerable<Product> Products { get; set; }
}