using EcommercModels;
    using ECommerceContext;
    using Microsoft.EntityFrameworkCore;
    
    namespace ECommerceInfrastructure
    {
        public class CartItemRepository : GenericRepository<CartItem>
        {
            private readonly AppDBContext _context;
    
            public CartItemRepository(AppDBContext context) : base(context)
            {
                _context = context;
            }
    
            // Get cart items by user ID
            public async Task<IQueryable<CartItem>> GetByUserIdAsync(int userId)
            {
                return await Task.FromResult(
                    _context.CartItems
                        .AsNoTracking()
                        .Where(ci => ci.UserID == userId)
                );
            }
    
            // Get cart item by user ID and product ID
            public async Task<CartItem?> GetByUserAndProductAsync(int userId, int productId)
            {
                return await _context.CartItems
                    .AsNoTracking()
                    .FirstOrDefaultAsync(ci => ci.UserID == userId && ci.ProductID == productId);
            }
        }
    }