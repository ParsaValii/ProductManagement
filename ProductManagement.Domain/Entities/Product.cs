namespace ProductManagement.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public DateTime ProduceDate { get; set; } = DateTime.Now;

    public required string ManufacturePhone { get; set; }

    public required string ManufactureEmail { get; set; }
    public bool IsAvailable { get; set; }
}
