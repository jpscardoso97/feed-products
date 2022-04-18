namespace Data.Importers.SoftwareAdvice.Parser;

using System.Text.Json.Serialization;

public class Product
{
    [JsonPropertyName("categories")] 
    public IEnumerable<string> Categories { get; set; }


    [JsonPropertyName("twitter")] 
    public string? Twitter { get; set; }


    [JsonPropertyName("title")] 
    public string Title { get; set; }
}