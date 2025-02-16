using MediatR;

namespace ProductManagement.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommandRequest(Guid Id, string Name, string ManufacturePhone, string ManufactureEmail, bool IsAvailable) : IRequest<UpdateProductCommandResponse>;
