using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Interfaces.ProductInterface;

namespace ProductManagement.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
