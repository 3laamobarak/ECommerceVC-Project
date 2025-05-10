using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDTOs;
namespace ECommerceApplication.Services.UserServices
{
    public interface IUserService
    {
        Task<User> GetUserDetailsAsync(int userId);
        Task UpdateUserAsync(User updatedUser, string newPassword = null);
    }
}