using ECommerceContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure
{
    public class GenericRepository<T> where T:class
    {
        private readonly AppDBContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDBContext AppDbContext)
        {
            _appDbContext = AppDbContext;
            _dbSet = _appDbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var result = (await _dbSet.AddAsync(entity)).Entity;
            await _appDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            var result = _dbSet.Update(entity).Entity;
            await _appDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<T> RemoveAsync(T entity)
        {
            var result = _dbSet.Remove(entity).Entity;
            await _appDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<T?> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }
    }
}
