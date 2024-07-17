using MediatR;

namespace ProductManagement.Application.Products.Commands.CreateProduct;

public record CreateProductCommandRequest(string Name, string ManufacturePhone, string ManufactureEmail, bool IsAvailable) : IRequest<CreateProductCommandResponse>;
