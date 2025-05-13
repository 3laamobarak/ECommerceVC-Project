using EcommercModels;
using ECommerceContext;
using ECommerceModels.Enums;
using Microsoft.EntityFrameworkCore;
using ECommerceApplication.Contracts;
using ECommerceDTOs;

namespace ECommerceInfrastructure
{
    public class OrderRepository : GenericRepository<Order> , IOrderRepository
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
        //        public Task<OrderDto> GetTheOrderByIdAsync(int id);
        public async Task<Order> GetTheOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
            {
                return null;
            }

            return new Order
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetail
                {
                    OrderID = od.OrderID,
                    ProductID = od.ProductID,
                    Quantity = od.Quantity,
                }).ToList()
            };
        }
        public async Task UpdateTotalAmountAsync(int orderId, decimal amountToAdd)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Order with ID {orderId} not found");

            order.TotalAmount += amountToAdd;
            await _context.SaveChangesAsync();
        }

}
}