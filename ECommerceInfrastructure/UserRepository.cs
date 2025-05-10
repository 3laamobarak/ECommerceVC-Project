using ECommerceApplication.Contracts;
using ECommerceContext;
using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDTOs;

namespace ECommerceInfrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<User> GetByUsernameOrEmailAsync(string identifier)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == identifier || u.Email == identifier);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }
        public async Task<bool> ActivateUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.IsActive = IsActive.Active;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeactivateUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.IsActive = IsActive.Inactive;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}