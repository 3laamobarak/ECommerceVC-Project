namespace ECommerceApplication.Services.CategoryService;
using EcommercModels;
public interface ICategoryService
{
    public Task<Category?> GetByNameAsync(string name);
    public Task<IEnumerable<Category>> SearchAsync(string keyword);
    public Task<Category?> GetByIdAsync(int id);
    public Task<IQueryable<Category>> GetAllAsync();
    public Task<Category> AddAsync(Category entity);
    public Task<Category> UpdateAsync(Category entity);
    public Task<Category> DeleteAsync(int id);
    
}