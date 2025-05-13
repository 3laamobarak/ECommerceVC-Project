using System.Diagnostics;
using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceContext;
using ECommerceDTOs;
using EcommercModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Services.CartItemService
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMappingService _mapper;
        private readonly AppDBContext _context;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductRepository _productRepository;
        
        public CartItemService(ICartItemRepository cartItemRepository, IMappingService mapper, AppDBContext context,
            IOrderService orderService, IOrderDetailService orderDetailService, IProductRepository productRepository)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _productRepository = productRepository;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        public async Task<bool> CheckoutAsync(int userId)
        {
            try
            {
                var cartItems = await _cartItemRepository.GetByUserIdAsync(userId);
                var cartItemList = cartItems.ToList();
                if (!cartItemList.Any())
                    return false;

                // Create order
                var orderDto = new CreateOrderDto { UserID = userId };
                var createdOrder = await _orderService.CreateOrderAsync(orderDto);

                // Create order details
                decimal totalAmount = 0;
                foreach (var item in cartItemList)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductID);
                    if (product == null || product.UnitsInStock < item.Quantity)
                        throw new InvalidOperationException($"Insufficient stock for product ID {item.ProductID}");

                    var orderDetailDto = await _orderDetailService.CreateOrderwithuseridandproductidAsync(
                        createdOrder.OrderID, item.ProductID, item.Quantity);

                    totalAmount += product.Price * item.Quantity;

                    // Remove cart item
                    await _cartItemRepository.RemoveAsync(item);
                }

                // Update order total amount
                var orderUpdateDto = new OrderUpdateDto { TotalAmount = totalAmount };
                await _orderService.UpdateOrderAsync(createdOrder.OrderID, orderUpdateDto);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during checkout: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsByUserIdAsync(int userId)
        {
            var cartItems = await _cartItemRepository.GetByUserIdAsync(userId);
            return cartItems.Select(ci => _mapper.MapToCartItemDto(ci));
        }

        public async Task<CartItemDto> GetCartItemByUserAndProductAsync(int userId, int productId)
        {
            var cartItem = await _cartItemRepository.GetByUserAndProductAsync(userId, productId);
            return cartItem != null ? _mapper.MapToCartItemDto(cartItem) : null;
        }

        public async Task<CartItemDto> AddCartItemAsync(CartItemDto cartItemDto)
        {
            var cartItem = _mapper.MapToCartItemEntity(cartItemDto);
            var createdCartItem = await _cartItemRepository.CreateAsync(cartItem);
            return _mapper.MapToCartItemDto(createdCartItem);
        }

        public async Task<CartItemDto> UpdateCartItemAsync(int cartItemId, CartItemDto cartItemDto)
        {
            var existingCartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (existingCartItem == null)
                throw new KeyNotFoundException($"Cart item with ID {cartItemId} not found");

            existingCartItem.Quantity = cartItemDto.Quantity;
            var updatedCartItem = await _cartItemRepository.UpdateAsync(existingCartItem);
            return _mapper.MapToCartItemDto(updatedCartItem);
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
                return false;

            await _cartItemRepository.RemoveAsync(cartItem);
            return true;
        }
        public async Task<CartItemDto> AddOrUpdateCartItemAsync(int userId, int productId, int quantity)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserID == userId && ci.ProductID == productId);

            if (cartItem != null)
            {
                // Update existing cart item
                cartItem.Quantity += quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                // Add new cart item
                cartItem = new CartItem
                {
                    UserID = userId,
                    ProductID = productId,
                    Quantity = quantity,
                    DateAdded = DateTime.Now
                };
                _context.CartItems.Add(cartItem);
                await _context.SaveChangesAsync();
            }

            // Map to DTO
            return new CartItemDto
            {
                CartItemID = cartItem.CartItemID,
                UserID = cartItem.UserID,
                ProductID = cartItem.ProductID,
                Quantity = cartItem.Quantity,
                DateAdded = cartItem.DateAdded,
                Product = new ProductDto { Name = cartItem.Product?.Name ?? "Unknown" },
                User = new UserDto { Username = cartItem.User?.Username ?? "Unknown" }
            };
        }
    }
}