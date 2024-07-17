using AutoMapper;
using MediatR;
using ProductManagement.Domain.Interfaces.ProductInterface;

namespace ProductManagement.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
