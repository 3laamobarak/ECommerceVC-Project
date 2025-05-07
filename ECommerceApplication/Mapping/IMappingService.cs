using ECommerceDTOs;
using EcommercModels;
namespace ECommerceApplication.Mapping
{
    public interface IMappingService
    {
        // User mappings
        UserDto MapToUserDto(User user);
        User MapToUserEntity(UserDto userDto);

        // Product mappings
        ProductDto MapToProductDto(Product product);
        Product MapToProductEntity(ProductDto productDto);
    
        // Category mappings
        CategoryDto MapToCategoryDto(Category category);
        Category MapToCategoryEntity(CategoryDto categoryDto);
    
        // Order mappings
        OrderDto MapToOrderDto(Order order);
        Order MapToOrderEntity(OrderDto orderDto);
    
        // OrderDetail mappings
        OrderDetailDto MapToOrderDetailDto(OrderDetail orderDetail);
        OrderDetail MapToOrderDetailEntity(OrderDetailDto orderDetailDto);
    
        // CartItem mappings
        CartItemDto MapToCartItemDto(CartItem cartItem);
        CartItem MapToCartItemEntity(CartItemDto cartItemDto);
    }
}
