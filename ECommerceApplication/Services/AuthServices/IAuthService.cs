using ECommerceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Services.AuthServices
{
 public interface IAuthService
    {
         Task<LoginResultDto> LoginAsync(LoginDto loginDto);
         Task<RegistrationResultDTO> RegisterAsync(RegisterUserDto dto);
         Task<ValidationResultDTO> UpdateUserAsync( UpdateUserDTO updatedUser);
         Task<UpdateUserResultDTO> ChangePasswordAsync(int userId, string oldPassword, string newPassword);


    }
}

