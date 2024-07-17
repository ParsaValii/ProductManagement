using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductManagement.Application.Products.Queries.GetProductById;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces.ProductInterface;
using Xunit;

namespace ProductManagement.Tests.ProductsTests
{
    public class GetProductByIdQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetProductByIdQueryHandler _handler;

        public GetProductByIdQueryHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetProductByIdQueryHandler(_mapperMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnProduct()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product { Id = productId, Name = "Product1", ProduceDate = DateTime.Now, ManufacturePhone = "123456", ManufactureEmail = "test@example.com", IsAvailable = true};
            var productResponse = new GetProductByIdQueryResponse(product.Id, product.Name, product.ProduceDate, product.ManufacturePhone, product.ManufactureEmail, product.IsAvailable);

            _productRepositoryMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(product);
            _mapperMock.Setup(m => m.Map<GetProductByIdQueryResponse>(product)).Returns(productResponse);

            // Act
            var result = await _handler.Handle(new GetProductByIdQueryRequest(productId), CancellationToken.None);

            // Assert
            Assert.Equal(productResponse, result);
        }
    }
}