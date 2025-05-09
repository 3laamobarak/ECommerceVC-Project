using ECommerceDTOs;

namespace ECommerceApplication.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetByNameAsync(string name);
        Task<IEnumerable<CategoryDto>> SearchAsync(string keyword);
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> AddAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateAsync(CategoryDto categoryDto);
        Task<bool> DeleteAsync(int id);
    }
}