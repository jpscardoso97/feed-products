namespace Data.Dto;

public class Product
{
    public string Name { get; set; }

    public IEnumerable<string> Categories { get; set; }
}