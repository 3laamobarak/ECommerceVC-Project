using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
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

        public CartItemService(ICartItemRepository cartItemRepository, IMappingService mapper, AppDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
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