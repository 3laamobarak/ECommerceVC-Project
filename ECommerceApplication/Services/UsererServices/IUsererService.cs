using ECommerceDTOs;
using ECommerceModels.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApplication.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDetailDTO> GetUserDetailsAsync(int userId);
        Task<UpdateUserResultDTO> UpdateUserAsync(int userId, UserDto updatedUser, string password);
        Task<UpdateUserResultDTO> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        Task<UpdateUserResultDTO> ActivateUserAsync(int userId);
        Task<UpdateUserResultDTO> DeactivateUserAsync(int userId);
        Task<UpdateUserResultDTO> ChangeRoleAsync(int userId, UserRole newRole);
        Task<UpdateUserResultDTO> UpdateUserWithoutPasswordAsync(int userId, UserDto updatedUser);
    }
    
}