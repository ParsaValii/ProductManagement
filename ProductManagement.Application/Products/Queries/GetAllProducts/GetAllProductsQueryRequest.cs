using MediatR;

namespace ProductManagement.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQueryRequest(): IRequest<List<GetAllProductsQueryResponse>>;
