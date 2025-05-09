using ECommerceApplication.Contracts;
using ECommerceDTOs;
using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApplication.Mapping
{
    /// <summary>
    /// Implementation of IMappingService that handles mapping between domain entities and DTOs
    /// </summary>
    public class MappingService : IMappingService
    {
        #region User Mappings

        public UserDto MapToUserDto(User user)
        {
            if (user == null) return null;

            return new UserDto
            {
                UserID = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                IsActive = user.IsActive,
                DateCreated = user.DateCreated,
                LastLoginDate = user.LastLoginDate
                // Note: Password is intentionally not mapped for security
            };
        }

        public User MapToUserEntity(UserDto userDto)
        {
            if (userDto == null) return null;

            return new User
            {
                Id = userDto.UserID,
                Username = userDto.Username,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Role = userDto.Role,
                IsActive = userDto.IsActive,
                DateCreated = userDto.DateCreated,
                LastLoginDate = userDto.LastLoginDate
                // Note: Password should be handled separately with proper hashing
            };
        }

        #endregion

        #region Product Mappings

        public Product MapToProduct(ProductDto productDto)
        {
            if (productDto == null) return null;

            return new Product
            {
                ProductID = productDto.ProductID,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                UnitsInStock = productDto.UnitsInStock,
                CategoryID = productDto.CategoryID,
                ImagePath = productDto.ImagePath
            };
        }

        public ProductDto MapToProductDto(Product product)
        {
            if (product == null) return null;

            return new ProductDto
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UnitsInStock = product.UnitsInStock,
                CategoryID = product.CategoryID,
                ImagePath = product.ImagePath
            };
        }
        
        #endregion
        
        #region Category Mappings
        
        public CategoryDto MapToCategoryDto(Category category)
        {
            if (category == null) return null;
            
            return new CategoryDto
            {
                CategoryID = category.CategoryID,
                Name = category.Name,
                Description = category.Description,
                // Optionally map Products if they're loaded
                Products = category.Products?.Select(p => MapToProductDto(p)).ToList()
            };
        }

        public Category MapToCategoryEntity(CategoryDto categoryDto)
        {
            if (categoryDto == null) return null;
            
            return new Category
            {
                CategoryID = categoryDto.CategoryID,
                Name = categoryDto.Name,
                Description = categoryDto.Description
                // Products relationship is handled separately
            };
        }
        
        #endregion
        
        #region Order Mappings
        
        public OrderDto MapToOrderDto(Order order)
        {
            if (order == null) return null;
            
            return new OrderDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                DateProcessed = order.DateProcessed,
                // Map related entities if they're loaded
                User = order.User != null ? MapToUserDto(order.User) : null,
                OrderDetails = order.OrderDetails?.Select(od => MapToOrderDetailDto(od)).ToList()
            };
        }

        public Order MapToOrderEntity(OrderDto orderDto)
        {
            if (orderDto == null) return null;
            
            return new Order
            {
                OrderID = orderDto.OrderID,
                UserID = orderDto.UserID,
                OrderDate = orderDto.OrderDate,
                TotalAmount = orderDto.TotalAmount,
                Status = orderDto.Status,
                DateProcessed = orderDto.DateProcessed
                // Relationships are handled separately
            };
        }
        
        #endregion
        
        #region OrderDetail Mappings
        
        public OrderDetailDto MapToOrderDetailDto(OrderDetail orderDetail)
        {
            if (orderDetail == null) return null;
            
            return new OrderDetailDto
            {
                OrderDetailID = orderDetail.OrderDetailID,
                OrderID = orderDetail.OrderID,
                ProductID = orderDetail.ProductID,
                Quantity = orderDetail.Quantity,
                // Map related entities if they're loaded
                Product = orderDetail.Product != null ? MapToProductDto(orderDetail.Product) : null
            };
        }

        public OrderDetail MapToOrderDetailEntity(OrderDetailDto orderDetailDto)
        {
            if (orderDetailDto == null) return null;
            
            return new OrderDetail
            {
                OrderDetailID = orderDetailDto.OrderDetailID,
                OrderID = orderDetailDto.OrderID,
                ProductID = orderDetailDto.ProductID,
                Quantity = orderDetailDto.Quantity
                // Relationships are handled separately
            };
        }
        
        #endregion
        
        #region CartItem Mappings
        
        public CartItemDto MapToCartItemDto(CartItem cartItem)
        {
            if (cartItem == null) return null;
            
            return new CartItemDto
            {
                CartItemID = cartItem.CartItemID,
                UserID = cartItem.UserID,
                ProductID = cartItem.ProductID,
                Quantity = cartItem.Quantity,
                DateAdded = cartItem.DateAdded,
                // Map related entities if they're loaded
                Product = cartItem.Product != null ? MapToProductDto(cartItem.Product) : null,
                User = cartItem.User != null ? MapToUserDto(cartItem.User) : null
            };
        }

        public CartItem MapToCartItemEntity(CartItemDto cartItemDto)
        {
            if (cartItemDto == null) return null;
            
            return new CartItem
            {
                CartItemID = cartItemDto.CartItemID,
                UserID = cartItemDto.UserID,
                ProductID = cartItemDto.ProductID,
                Quantity = cartItemDto.Quantity,
                DateAdded = cartItemDto.DateAdded
                // Relationships are handled separately
            };
        }
        
        #endregion
    }
}