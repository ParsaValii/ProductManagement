using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.Interfaces.ProductInterface;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product order);
    Task UpdateAsync(Product order);
    Task DeleteAsync(Guid id);
}
