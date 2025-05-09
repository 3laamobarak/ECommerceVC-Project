using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceDTOs;
using EcommercModels;

namespace ECommerceApplication.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMappingService _mapper;

        public ProductService(IProductRepository productRepository, IMappingService mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAll();
            return products.Select(p => _mapper.MapToProductDto(p));
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product != null ? _mapper.MapToProductDto(product) : null;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            var product = _mapper.MapToProduct(productDto);
            var createdProduct = await _productRepository.CreateAsync(product);
            return _mapper.MapToProductDto(createdProduct);
        }

        public async Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found");

            product.Name = productDto.Name ?? product.Name;
            product.Description = productDto.Description ?? product.Description;
            product.Price = productDto.Price;
            product.UnitsInStock = productDto.UnitsInStock;
            product.CategoryID = productDto.CategoryID;
            product.ImagePath = productDto.ImagePath ?? product.ImagePath;

            var updatedProduct = await _productRepository.UpdateAsync(product);
            return _mapper.MapToProductDto(updatedProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;

            await _productRepository.RemoveAsync(product);
            return true;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetByCategoryAsync(categoryId);
            return products.Select(p => _mapper.MapToProductDto(p));
        }

        public async Task<IEnumerable<ProductDto>> SearchProductsByNameAsync(string name)
        {
            var products = await _productRepository.SearchByNameAsync(name);
            return products.Select(p => _mapper.MapToProductDto(p));
        }

        public async Task<IEnumerable<ProductDto>> GetLowStockProductsAsync(int threshold)
        {
            var products = await _productRepository.GetLowStockProductsAsync(threshold);
            return products.Select(p => _mapper.MapToProductDto(p));
        }
    }
}