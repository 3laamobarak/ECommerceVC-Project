using EcommercModels;
namespace ECommerceApplication.Contracts
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        public Task<IQueryable<CartItem>> GetByUserIdAsync(int userId);
        public Task<CartItem?> GetByUserAndProductAsync(int userId, int productId);
    }
}
