using ECommerceDTOs;

namespace ECommerceApplication.Services.CartItemService
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItemDto>> GetCartItemsByUserIdAsync(int userId);
        Task<CartItemDto> GetCartItemByUserAndProductAsync(int userId, int productId);
        Task<CartItemDto> AddCartItemAsync(CartItemDto cartItemDto);
        Task<CartItemDto> UpdateCartItemAsync(int cartItemId, CartItemDto cartItemDto);
        Task<bool> RemoveCartItemAsync(int cartItemId);
        Task<CartItemDto> AddOrUpdateCartItemAsync(int userId, int productId, int quantity);

    }
}