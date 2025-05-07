using EcommercModels;
using ECommerceContext;
using ECommerceModels.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure
{
    public class OrderRepository : GenericRepository<Order>
    {
        private readonly AppDBContext _context;

        public OrderRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        // Get orders by user ID
        public async Task<IQueryable<Order>> GetByUserIdAsync(int userId)
        {
            return await Task.FromResult(
                _context.Orders
                    .AsNoTracking()
                    .Where(o => o.UserID == userId)
            );
        }

        // Get orders by status
        public async Task<IQueryable<Order>> GetByStatusAsync(OrderStatus status)
        {
            return await Task.FromResult(
                _context.Orders
                    .AsNoTracking()
                    .Where(o => o.Status == status)
            );
        }
    }
}