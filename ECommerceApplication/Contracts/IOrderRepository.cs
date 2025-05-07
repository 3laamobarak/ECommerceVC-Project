using EcommercModels;
using ECommerceModels.Enums;

namespace ECommerceApplication.Contracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<IQueryable<Order>> GetByUserIdAsync(int userId);
        public Task<IQueryable<Order>> GetByStatusAsync(OrderStatus status);
    }
}