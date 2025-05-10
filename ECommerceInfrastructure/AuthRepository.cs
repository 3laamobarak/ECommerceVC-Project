using ECommerceApplication.Contracts;
using ECommerceContext;
using EcommercModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure
{
   public class AuthRepository:IAuthRepository
    {
        private readonly AppDBContext _context;
        public AuthRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<User> GetByUsernameOrEmailAsync(string identifier)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == identifier || u.Email == identifier);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }


    }
}
