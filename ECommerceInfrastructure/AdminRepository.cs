using ECommerceApplication.Contracts;
using ECommerceContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore;
namespace ECommerceInfrastructure
{
    public class AdminRepository : UserRepository, IAdminRepository
    {
        private readonly AppDBContext _context;

        public AdminRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }



        //public async Task<List<User>> GetUsersByRoleAsync(UserRole role)
        //{
        //    return await _context.Users
        //                         .Where(u => u.Role == role)
        //                         .ToListAsync();
        //}


    }

}
