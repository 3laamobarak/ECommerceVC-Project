using EcommercModels;

namespace ECommerceApplication.Contracts
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        public Task<IQueryable<OrderDetail>> GetByOrderIdAsync(int orderId);
    }
}