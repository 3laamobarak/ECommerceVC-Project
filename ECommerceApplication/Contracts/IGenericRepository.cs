using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IQueryable<T>> GetAll();
        public Task<T?> CreateAsync(T entity);
        public Task<T?> UpdateAsync(T entity);
        public Task<T?> RemoveAsync(T entity);
        public Task<T?> GetByIdAsync(int Id);
    }
}
