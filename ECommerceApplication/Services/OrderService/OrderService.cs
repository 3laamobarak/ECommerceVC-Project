using ECommerceDTOs;
using ECommerceApplication.Contracts;
using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore;
using ECommerceApplication.Mapping;
using ECommerceContext;

namespace ECommerceApplication.Services.IOrderDetailsService

{
    public class OrderService : IOrderService
    {
     private readonly IOrderRepository _orderRepository;
     private readonly IOrderDetailRepository _orderDetailRepository;
     private readonly IMappingService _mapper;
     private readonly AppDBContext _context;

     public OrderService(
         IOrderRepository orderRepository, 
         IOrderDetailRepository orderDetailRepository,
            AppDBContext context,
         IMappingService mapper)
     { 
         _context = context;
         _orderRepository = orderRepository;
         _orderDetailRepository = orderDetailRepository;
         _mapper = mapper;
     }

     // public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
     // {
     //     var orders = await _orderRepository.GetAll();
     //     return await orders.Select(o => _mapper.MapToOrderDto(o)).ToListAsync();
     // }
     public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
     {
         return await _context.Orders
             .Include(o => o.User)
             .Include(o => o.OrderDetails)
             .ThenInclude(od => od.Product)
             .Select(o => new OrderDto
             {
                 OrderID = o.OrderID,
                 UserID = o.UserID,
                 OrderDate = o.OrderDate,
                 TotalAmount = o.TotalAmount,
                 Status = o.Status,
                 User = new UserDto { UserID = o.User.Id, Username = o.User.Username, FirstName = o.User.FirstName, LastName = o.User.LastName },
                 OrderDetails = o.OrderDetails.Select(od => new OrderDetailDto
                 {
                     OrderDetailID = od.OrderDetailID,
                     OrderID = od.OrderID,
                     ProductID = od.ProductID,
                     Quantity = od.Quantity,
                     Product = new ProductDto { ProductID = od.Product.ProductID, Name = od.Product.Name }
                 }).ToList()
             })
             .ToListAsync();
     }

     public async Task<OrderDto> GetOrderByIdAsync(int id)
     {
         var order = await _orderRepository.GetByIdAsync(id);
         return order != null ? _mapper.MapToOrderDto(order) : null;
     }

     public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId)
     {
         var orders = await _orderRepository.GetByUserIdAsync(userId);
         return await orders.Select(o => _mapper.MapToOrderDto(o)).ToListAsync();
     }

     public async Task<IEnumerable<OrderDto>> GetOrdersByStatusAsync(OrderStatus status)
     {
         var orders = await _orderRepository.GetByStatusAsync(status);
         return await orders.Select(o => _mapper.MapToOrderDto(o)).ToListAsync();
     }

     public async Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto)
     {
         // Create new order
         var order = new Order
         {
             UserID = orderDto.UserID,
             OrderDate = DateTime.UtcNow,
             Status = OrderStatus.Pending,
             TotalAmount = 0 // Will be calculated from order details
         };
         
         var createdOrder = await _orderRepository.CreateAsync(order);
         
         // Return the mapped order
         return _mapper.MapToOrderDto(createdOrder);
     }

     public async Task<OrderDto> UpdateOrderAsync(int orderId, OrderUpdateDto orderDto)
     {
         var order = await _orderRepository.GetByIdAsync(orderId);
         if (order == null)
             throw new KeyNotFoundException($"Order with ID {orderId} not found");

         // Update order properties that are allowed to be updated
         if (orderDto.Status.HasValue)
             order.Status = orderDto.Status.Value;
             
         if (orderDto.TotalAmount.HasValue)
             order.TotalAmount = orderDto.TotalAmount.Value;

         var updatedOrder = await _orderRepository.UpdateAsync(order);
         return _mapper.MapToOrderDto(updatedOrder);
     }

     public async Task<bool> DeleteOrderAsync(int id)
     {
         var order = await _orderRepository.GetByIdAsync(id);
         if (order == null)
             return false;

         // First delete associated order details
         var orderDetails = await _orderDetailRepository.GetByOrderIdAsync(id);
         var orderDetailsList = await orderDetails.ToListAsync();
         
         foreach (var detail in orderDetailsList)
         {
             await _orderDetailRepository.RemoveAsync(detail);
         }

         // Then delete the order
         await _orderRepository.RemoveAsync(order);
         return true;
     }

     public async Task<bool> ChangeOrderStatusAsync(int orderId, OrderStatus newStatus)
     {
         var order = await _orderRepository.GetByIdAsync(orderId);
         if (order == null)
             return false;

         order.Status = newStatus;
         
         // If the order is completed, set completion date
         if (newStatus == OrderStatus.Approved || newStatus == OrderStatus.Shipped)
         {
             order.DateProcessed = DateTime.UtcNow;
         }
         
         await _orderRepository.UpdateAsync(order);
         return true;
     }

     public async Task<OrderDto> GetOrderWithDetailsAsync(int orderId)
     {
         var order = await _orderRepository.GetByIdAsync(orderId);
         if (order == null)
             return null;
             
         // Get order details
         var detailsQuery = await _orderDetailRepository.GetByOrderIdAsync(orderId);
         var details = await detailsQuery.ToListAsync();
         
         // Create the order DTO
         var orderDto = _mapper.MapToOrderDto(order);
         
         // Map and attach order details
         orderDto.OrderDetails = details.Select(d => _mapper.MapToOrderDetailDto(d)).ToList();
         
         return orderDto;
     }
 }
}