using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductManagement.Application.Products.Queries.GetAllProducts;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces.ProductInterface;
using Xunit;

namespace ProductManagement.Tests.ProductsTests
{
    public class GetAllProductsQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetAllProductsQueryHandler _handler;

        public GetAllProductsQueryHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllProductsQueryHandler(_productRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllProductsQueryHandler_ShouldReturnListOfProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product1", ProduceDate = DateTime.Now, ManufacturePhone = "123456", ManufactureEmail = "test1@example.com", IsAvailable = true},
                new Product { Id = Guid.NewGuid(), Name = "Product2", ProduceDate = DateTime.Now, ManufacturePhone = "123456", ManufactureEmail = "test2@example.com", IsAvailable = true}
            };

            var productResponses = new List<GetAllProductsQueryResponse>
            {
                new GetAllProductsQueryResponse(products[0].Id, products[0].Name, products[0].ProduceDate, products[0].ManufacturePhone, products[0].ManufactureEmail, products[0].IsAvailable),
                new GetAllProductsQueryResponse(products[1].Id, products[1].Name, products[1].ProduceDate, products[1].ManufacturePhone, products[1].ManufactureEmail, products[1].IsAvailable)
            };

            _productRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
            _mapperMock.Setup(m => m.Map<List<GetAllProductsQueryResponse>>(products)).Returns(productResponses);

            // Act
            var result = await _handler.Handle(new GetAllProductsQueryRequest(), CancellationToken.None);

            // Assert
            Assert.Equal(productResponses, result);
        }
    }
}