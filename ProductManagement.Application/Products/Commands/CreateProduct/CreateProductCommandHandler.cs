using AutoMapper;
using MediatR;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces.ProductInterface;

namespace ProductManagement.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
