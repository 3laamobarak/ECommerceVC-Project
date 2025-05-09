using ECommerceApplication.Contracts;
using ECommerceContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure
{
    public class GenericRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDBContext AppDbContext)
        {
            _context = AppDbContext;
            _dbSet = _context.Set<T>();
        }
        public async Task<IQueryable<T>> GetAll()
        {
            return await Task.FromResult(_dbSet.AsNoTracking());
        }
        public async Task<T?> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var result = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<T?> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var result = _dbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<T?> RemoveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            //var existingEntity = await _dbSet.FindAsync(entity);
            // if (existingEntity == null)
            // {
            //     throw new ArgumentException("Entity not found in the database.");
            // }
            var result = _dbSet.Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<T?> GetByIdAsync(int Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            return entity ?? throw new ArgumentException("Entity not found in the database.");
        }
    }
}
