using EcommercModels;
using ECommerceContext;
using Microsoft.EntityFrameworkCore;
using ECommerceApplication.Contracts;

namespace ECommerceInfrastructure
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
            private readonly AppDBContext _context;
    
            public ProductRepository(AppDBContext context) : base(context)
            {
                _context = context;
            }
    
            // Get products by category ID
            public async Task<IQueryable<Product>> GetByCategoryAsync(int categoryId)
            {
                return await Task.FromResult(
                    _context.Products
                        .AsNoTracking()
                        .Where(p => p.CategoryID == categoryId)
                );
            }
    
            // Search products by name
            public async Task<IQueryable<Product>> SearchByNameAsync(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException(nameof(name));
                }
    
                return await Task.FromResult(
                    _context.Products
                        .AsNoTracking()
                        .Where(p => p.Name.Contains(name))
                );
            }
    
            // Get all products with low stock (e.g., less than a specified threshold)
            public async Task<IQueryable<Product>> GetLowStockProductsAsync(int threshold)
            {
                return await Task.FromResult(
                    _context.Products
                        .AsNoTracking()
                        .Where(p => p.UnitsInStock < threshold)
                );
            }
        }
    }