namespace ProductManagement.Application.Products.Queries.GetProductById;

public record GetProductByIdQueryResponse(Guid Id, string Name, DateTime ProduceDate, string ManufacturePhone, string ManufactureEmail, bool IsAvailable);
