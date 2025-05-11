using ECommerceApplication.Contracts;
using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<User>> GetAllByRole(UserRole role)
        {
            return await _adminRepository.GetAll().Where(u=>u.Role == role).ToListAsync();
        }

        public async Task ActivateUserAsync(int userId)
        {
            var user = await _adminRepository.GetByIdAsync(userId);
            if (user != null)
            {
                user.IsActive = IsActive.Inactive;
                await _adminRepository.UpdateAsync(user);
            }
        }

        public async Task DeactivateUserAsync(int userId)
        {
            var user = await _adminRepository.GetByIdAsync(userId);
            if (user != null)
            {
                user.IsActive = IsActive.Active;
                await _adminRepository.UpdateAsync(user);
            }
        }

        //public async Task AddAdminUserAsync(User newAdmin)
        //{
        //    newAdmin.Role =UserRole.Admin;
        //    newAdmin.IsActive = IsActive.Active;
        //    await _adminRepository.AddUserAsync(newAdmin);
        //}
    }
}
