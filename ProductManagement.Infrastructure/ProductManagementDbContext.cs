using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure;

public class ProductManagementDbContext : DbContext
{
    public ProductManagementDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}
