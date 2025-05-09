using ECommerceDTOs;
        
        namespace ECommerceApplication.Services.ProductService
        {
            public interface IProductService
            {
                Task<IEnumerable<ProductDto>> GetAllProductsAsync();
                Task<ProductDto> GetProductByIdAsync(int id);
                Task<ProductDto> CreateProductAsync(ProductDto productDto);
                Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto);
                Task<bool> DeleteProductAsync(int id);
                Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
                Task<IEnumerable<ProductDto>> SearchProductsByNameAsync(string name);
                Task<IEnumerable<ProductDto>> GetLowStockProductsAsync(int threshold);
            }
        }