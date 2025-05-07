using ECommerceApplication.Contracts;
using EcommercModels;
    using ECommerceContext;
    using Microsoft.EntityFrameworkCore;
    
    namespace ECommerceInfrastructure
    {
        public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
        {
            private readonly AppDBContext _context;
    
            public CategoryRepository(AppDBContext context) : base(context)
            {
                _context = context;
            }
   
            public async Task<IEnumerable<Category>> SearchAsync(string keyword)
            {
                return await _context.Categories
                    .Where(c => c.Name.Contains(keyword))
                    .ToListAsync();
            }
            // Get category by name
            public async Task<Category?> GetByNameAsync(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException(nameof(name));
                }
    
                return await _context.Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Name == name);
            }
        }
    }