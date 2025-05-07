using ECommerceDTOs;
namespace ECommerceApplication.Services.IOrderDetailsService
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync();
        Task<OrderDetailDto> GetOrderDetailByIdAsync(int id);
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task<OrderDetailDto> CreateOrderDetailAsync(CreateOrderDetailDto orderDetailDto, int orderId);
        Task<OrderDetailDto> UpdateOrderDetailAsync(int orderDetailId, UpdateOrderDetailDto orderDetailDto);
        Task<bool> DeleteOrderDetailAsync(int id);
    }
}