using ECommerceModels.Enums;
using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Services.AdminServices
{
    public interface IAdminService
    {
        Task<List<User>> GetAllByRole(UserRole role);// admin or client 
        Task ActivateUserAsync(int userId); // active user or admin
        Task DeactivateUserAsync(int userId); // deactivate user or admin
        //Task AddAdminUserAsync(User newAdmin);
    }
}
