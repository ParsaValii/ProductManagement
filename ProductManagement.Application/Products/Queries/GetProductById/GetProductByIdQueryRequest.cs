using MediatR;

namespace ProductManagement.Application.Products.Queries.GetProductById;

public record GetProductByIdQueryRequest(Guid Id) : IRequest<GetProductByIdQueryResponse>;
