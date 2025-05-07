using ECommerceDTOs;
using ECommerceApplication.Contracts;
using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore;
using ECommerceApplication.Mapping;
namespace ECommerceApplication.Services.IOrderDetailsService
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMappingService _mapper;

        public OrderDetailService(
            IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository,
            IMappingService mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAll();
            return await orderDetails.Select(od => _mapper.MapToOrderDetailDto(od)).ToListAsync();
        }

        public async Task<OrderDetailDto> GetOrderDetailByIdAsync(int id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            return orderDetail != null ? _mapper.MapToOrderDetailDto(orderDetail) : null;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            var orderDetails = await _orderDetailRepository.GetByOrderIdAsync(orderId);
            return await orderDetails.Select(od => _mapper.MapToOrderDetailDto(od)).ToListAsync();
        }

        public async Task<OrderDetailDto> CreateOrderDetailAsync(CreateOrderDetailDto orderDetailDto, int orderId)
        {
            // Get product to verify it exists and get current price
            var product = await _productRepository.GetByIdAsync(orderDetailDto.ProductID);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {orderDetailDto.ProductID} not found");

            // Check if there's enough stock
            if (product.UnitsInStock < orderDetailDto.Quantity)
                throw new InvalidOperationException(
                    $"Not enough stock for product {product.Name}. Available: {product.UnitsInStock}, Requested: {orderDetailDto.Quantity}");

            // Create new order detail
            var orderDetail = new OrderDetail
            {
                OrderID = orderId,
                ProductID = orderDetailDto.ProductID,
                Quantity = orderDetailDto.Quantity,
                //UnitPrice = product.Price, // Use current product price
                //Subtotal = product.Price * orderDetailDto.Quantity
            };

            // Reduce product stock
            product.UnitsInStock -= orderDetailDto.Quantity;
            await _productRepository.UpdateAsync(product);

            var createdOrderDetail = await _orderDetailRepository.CreateAsync(orderDetail);
            return _mapper.MapToOrderDetailDto(createdOrderDetail);
        }

        public async Task<OrderDetailDto> UpdateOrderDetailAsync(int orderDetailId, UpdateOrderDetailDto orderDetailDto)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(orderDetailId);
            if (orderDetail == null)
                throw new KeyNotFoundException($"OrderDetail with ID {orderDetailId} not found");

            // Get product to check stock if quantity is being increased
            var product = await _productRepository.GetByIdAsync(orderDetail.ProductID);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {orderDetail.ProductID} not found");

            // Handle stock changes
            int quantityDifference = orderDetailDto.Quantity - orderDetail.Quantity;

            if (quantityDifference > 0)
            {
                // Check if there's enough stock for the additional quantity
                if (product.UnitsInStock < quantityDifference)
                    throw new InvalidOperationException(
                        $"Not enough stock for product {product.Name}. Available: {product.UnitsInStock}, Additional needed: {quantityDifference}");

                // Reduce product stock by the additional quantity
                product.UnitsInStock -= quantityDifference;
            }
            else if (quantityDifference < 0)
            {
                // Return units to stock if quantity is decreased
                product.UnitsInStock += Math.Abs(quantityDifference);
            }

            // Update product stock
            await _productRepository.UpdateAsync(product);

            // Update order detail
            orderDetail.Quantity = orderDetailDto.Quantity;
            //orderDetail.Subtotal = orderDetail.UnitPrice * orderDetail.Quantity;

            var updatedOrderDetail = await _orderDetailRepository.UpdateAsync(orderDetail);
            return _mapper.MapToOrderDetailDto(updatedOrderDetail);
        }

        public async Task<bool> DeleteOrderDetailAsync(int id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderDetail == null)
                return false;

            // Return quantity to product stock
            var product = await _productRepository.GetByIdAsync(orderDetail.ProductID);
            if (product != null)
            {
                product.UnitsInStock += orderDetail.Quantity;
                await _productRepository.UpdateAsync(product);
            }

            await _orderDetailRepository.RemoveAsync(orderDetail);
            return true;
        }
    }
}