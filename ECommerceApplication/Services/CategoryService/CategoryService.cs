using ECommerceApplication.Contracts;
using EcommercModels;
namespace ECommerceApplication.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<Category>> SearchAsync(string keyword)
        {
            return await _categoryRepository.SearchAsync(keyword);
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<IQueryable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> AddAsync(Category entity)
        {
            return await _categoryRepository.CreateAsync(entity);
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            return await _categoryRepository.UpdateAsync(entity);
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new ArgumentException("Category not found in the database.");
            }

            return await _categoryRepository.RemoveAsync(category);
        }
    }
}