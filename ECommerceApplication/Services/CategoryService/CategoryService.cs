using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceDTOs;
using EcommercModels;

namespace ECommerceApplication.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMappingService _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMappingService mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAll();
            return categories.Select(c => _mapper.MapToCategoryDto(c)).ToList();
        }

        public async Task<CategoryDto?> GetByNameAsync(string name)
        {
            var category = await _categoryRepository.GetByNameAsync(name);
            return category != null ? _mapper.MapToCategoryDto(category) : null;
        }

        public async Task<IEnumerable<CategoryDto>> SearchAsync(string keyword)
        {
            var categories = await _categoryRepository.SearchAsync(keyword);
            return categories.Select(c => _mapper.MapToCategoryDto(c));
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category != null ? _mapper.MapToCategoryDto(category) : null;
        }

        // public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        // {
        //     var categories = await _categoryRepository.GetAll();
        //     return categories.Select(c => _mapper.MapToCategoryDto(c));
        // }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var category = _mapper.MapToCategoryEntity(categoryDto);
            var createdCategory = await _categoryRepository.CreateAsync(category);
            return _mapper.MapToCategoryDto(createdCategory);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.MapToCategoryEntity(categoryDto);
            var updatedCategory = await _categoryRepository.UpdateAsync(category);
            return _mapper.MapToCategoryDto(updatedCategory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return false;

            await _categoryRepository.RemoveAsync(category);
            return true;
        }
    }
}