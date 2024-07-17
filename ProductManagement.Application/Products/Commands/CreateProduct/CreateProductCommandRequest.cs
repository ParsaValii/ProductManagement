using MediatR;

namespace ProductManagement.Application.Products.Commands.CreateProduct;

public record CreateProductCommandRequest(string Name, string ManufacturePhone, string ManufactureEmail, bool IsAvailable, Guid? UserId = null) : IRequest<CreateProductCommandResponse>;
