using EcommercModels;

namespace ECommerceApplication.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<IEnumerable<Category>> SearchAsync(string keyword);
        public Task<Category?> GetByNameAsync(string name);

    }
}