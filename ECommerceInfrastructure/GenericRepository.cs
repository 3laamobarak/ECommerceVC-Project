using ECommerceApplication.Contracts;
using ECommerceContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceInfrastructure
{
    public class GenericRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDBContext appDbContext)
        {
            _context = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _dbSet = _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return await Task.FromResult(_dbSet.AsNoTracking());
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = _dbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = _dbSet.Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Entity with ID {id} not found in the database.");
            }
            return entity;
        }
    }
}