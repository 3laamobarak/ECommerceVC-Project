using EcommercModels;
    using ECommerceContext;
    using Microsoft.EntityFrameworkCore;
    
    namespace ECommerceInfrastructure
    {
        public class OrderDetailRepository : GenericRepository<OrderDetail>
        {
            private readonly AppDBContext _context;
    
            public OrderDetailRepository(AppDBContext context) : base(context)
            {
                _context = context;
            }
    
            // Get order details by order ID
            public async Task<IQueryable<OrderDetail>> GetByOrderIdAsync(int orderId)
            {
                return await Task.FromResult(
                    _context.OrderDetails
                        .AsNoTracking()
                        .Where(od => od.OrderID == orderId)
                );
            }
        }
    }