using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceDTOs;
using EcommercModels;

namespace ECommerceApplication.Services.CartItemService
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMappingService _mapper;

        public CartItemService(ICartItemRepository cartItemRepository, IMappingService mapper)
        {
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
    }
}