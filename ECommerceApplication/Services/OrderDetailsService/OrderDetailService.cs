using ECommerceDTOs;
using ECommerceApplication.Contracts;
using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore;
using ECommerceApplication.Mapping;
using ECommerceApplication.Services.ProductService;

namespace ECommerceApplication.Services.IOrderDetailsService
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMappingService _mapper;
        private readonly IProductService _productService;

        public OrderDetailService(
            IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository,
            IProductService productService,
            IMappingService mapper)
        {
            _productService = productService;
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
        public async Task<OrderDetailDto> CreateOrderwithuseridandproductidAsync(int orderId, int productId, int quantity)
        {
            // Validate OrderID (optional, but good practice to ensure the order exists)
            if (orderId <= 0)
                throw new ArgumentException("Invalid OrderID. It must be greater than 0.", nameof(orderId));

            // Validate ProductID and quantity
            if (productId <= 0)
                throw new ArgumentException("Invalid ProductID. It must be greater than 0.", nameof(productId));
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.", nameof(quantity));

            // Get product to verify it exists
            var product = await _productService.GetProductByIdAsync(productId);
            //var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found");

            // Check if there's enough stock
            if (product.UnitsInStock < quantity)
                throw new InvalidOperationException(
                    $"Not enough stock for product {product.Name}. Available: {product.UnitsInStock}, Requested: {quantity}");

            // Create new order detail
            var orderDetail = new OrderDetail
            {
                OrderID = orderId,
                ProductID = productId,
                Quantity = quantity,
            };

            // Reduce product stock
            product.UnitsInStock -= quantity;
            await _productService.UpdateProductAsync(productId,product);

            // Save the order detail
            var createdOrderDetail = await _orderDetailRepository.CreateAsync(orderDetail);
            if (createdOrderDetail == null)
                throw new InvalidOperationException("Failed to create order detail in the repository.");

            // Map to DTO and return
            var orderDetailDto = _mapper.MapToOrderDetailDto(createdOrderDetail);
            if (orderDetailDto == null)
                throw new InvalidOperationException("Failed to map the created order detail to DTO.");

            return orderDetailDto;
        }
    }
}