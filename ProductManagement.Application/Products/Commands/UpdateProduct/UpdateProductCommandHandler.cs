using AutoMapper;
using MediatR;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces.ProductInterface;

namespace ProductManagement.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await _productRepository.UpdateAsync(product);
        return new UpdateProductCommandResponse(true);
    }
}
