using ECommerceDTOs;
using EcommercModels;
using ECommerceModels.Enums;

namespace ECommerceApplication.Services.IOrderDetailsService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task<IEnumerable<OrderDto>> GetOrdersByStatusAsync(OrderStatus status);
        Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto);
        Task<OrderDto> UpdateOrderAsync(int orderId, OrderUpdateDto orderDto);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> ChangeOrderStatusAsync(int orderId, OrderStatus newStatus);
        Task<OrderDto> GetOrderWithDetailsAsync(int orderId);
    }
}