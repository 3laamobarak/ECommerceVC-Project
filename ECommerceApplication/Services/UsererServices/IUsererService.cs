using EcommercModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceDTOs;

namespace ECommerceApplication.Services.UserServices
{
    public interface IUserService
    {
        Task<UserDetailDTO> GetUserDetailsAsync(int userId);
        Task<UpdateUserResultDTO> UpdateUserAsync(int userId, UserDetailDTO updatedUser, string password);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UpdateUserResultDTO> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    }
}