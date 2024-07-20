using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductManagement.Application.Products.Commands.UpdateProduct;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces.ProductInterface;
using Xunit;

namespace ProductManagement.Tests.ProductsTests
{
    public class UpdateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UpdateProductCommandHandler _handler;

        public UpdateProductCommandHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new UpdateProductCommandHandler(_mapperMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateProductAndReturnResponse()
        {
            // Arrange
            var request = new UpdateProductCommandRequest(Guid.NewGuid(), "Product1", "123456", "test@example.com", true);
            var product = new Product { Id = request.Id, Name = request.Name, ManufacturePhone = request.ManufacturePhone, ManufactureEmail = request.ManufactureEmail, IsAvailable = request.IsAvailable, ProduceDate = DateTime.Now };
            var response = new UpdateProductCommandResponse(true);

            _productRepositoryMock.Setup(repo => repo.UpdateAsync(product)).Returns(Task.CompletedTask);
            _mapperMock.Setup(m => m.Map<Product>(request)).Returns(product);
            _mapperMock.Setup(m => m.Map<UpdateProductCommandResponse>(It.IsAny<object>())).Returns(response);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(response, result);
        }
    }
}