using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductManagement.Application.Products.Commands.CreateProduct;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces.ProductInterface;
using Xunit;

namespace ProductManagement.Tests.ProductsTests
{
    public class CreateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateProductCommandHandler _handler;

        public CreateProductCommandHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateProductCommandHandler(_mapperMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateProductAndReturnResponse()
        {
            // Arrange
            var request = new CreateProductCommandRequest("Product1", "123456", "test@example.com", true);
            var product = new Product { Id = Guid.NewGuid(), Name = request.Name, ManufacturePhone = request.ManufacturePhone, ManufactureEmail = request.ManufactureEmail, IsAvailable = request.IsAvailable, ProduceDate = DateTime.Now };
            var response = new CreateProductCommandResponse(product.Id);

            _mapperMock.Setup(m => m.Map<Product>(request)).Returns(product);
            _productRepositoryMock.Setup(repo => repo.AddAsync(product)).Returns(Task.CompletedTask);
            _mapperMock.Setup(m => m.Map<CreateProductCommandResponse>(product)).Returns(response);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(response, result);
        }
    }
}