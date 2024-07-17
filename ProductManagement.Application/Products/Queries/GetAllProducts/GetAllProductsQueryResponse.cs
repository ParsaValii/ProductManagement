namespace ProductManagement.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQueryResponse(Guid Id, string Name, DateTime ProduceDate, string ManufacturePhone, string ManufactureEmail, bool IsAvailable, Guid UserId);
