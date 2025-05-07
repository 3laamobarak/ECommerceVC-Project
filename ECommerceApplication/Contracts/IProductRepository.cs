using EcommercModels;
    
    namespace ECommerceApplication.Contracts
    {
        public interface IProductRepository : IGenericRepository<Product>
        {
            public Task<IQueryable<Product>> GetByCategoryAsync(Guid categoryId);
            public Task<IQueryable<Product>> SearchByNameAsync(string name);
            public Task<IQueryable<Product>> GetLowStockProductsAsync(int threshold);
        }
    }