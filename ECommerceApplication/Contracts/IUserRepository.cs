using EcommercModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Contracts
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByUsernameOrEmailAsync(string identifier);
        Task<User> GetByIdAsync(int id);
        Task<bool>UpdateAsync(User user);
        IQueryable<User>GetAll();
        Task<bool> ActivateUser(int userId);
        Task<bool> DeactivateUser(int userId);
        
    }
}