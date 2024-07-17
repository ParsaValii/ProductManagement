using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductManagement.Application.Products.Commands.DeleteProduct;
using ProductManagement.Domain.Interfaces.ProductInterface;
using Xunit;

namespace ProductManagement.Tests.ProductsTests
{
    public class DeleteProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly DeleteProductCommandHandler _handler;

        public DeleteProductCommandHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new DeleteProductCommandHandler(_mapperMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteProductAndReturnResponse()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var request = new DeleteProductCommandRequest(productId);
            var response = new DeleteProductCommandResponse(true);

            _productRepositoryMock.Setup(repo => repo.DeleteAsync(productId)).Returns(Task.CompletedTask);
            _mapperMock.Setup(m => m.Map<DeleteProductCommandResponse>(It.IsAny<object>())).Returns(response);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(response, result);
        }
    }
}