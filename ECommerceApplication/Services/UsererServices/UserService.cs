using ECommerceApplication.Contracts;
using ECommerceApplication.PasswordHasherService;
using ECommerceDTOs;
using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApplication.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMappingService _mappingService;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IMappingService mappingService)
        {
            _mappingService = mappingService ?? throw new ArgumentNullException(nameof(mappingService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            try
            {
                var users = _userRepository.GetAll();
                var userList = await users.ToListAsync();
                return userList.Select(user => MapToUserDto(user));
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve users.", ex);
            }
        }

        public async Task<UserDetailDTO> GetUserDetailsAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            return new UserDetailDTO
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LastLoginDate = user.LastLoginDate,
                Role = user.Role,
                IsActive = user.IsActive
            };
        }

        public async Task<UpdateUserResultDTO> UpdateUserAsync(int userId, UserDto updatedUser, string password)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser));
            }

            if (string.IsNullOrEmpty(password))
            {
                return new UpdateUserResultDTO { Success = false, Message = "Password cannot be empty." };
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null || !_passwordHasher.VerifyPassword(user.Password, password))
            {
                return new UpdateUserResultDTO { Success = false, Message = "Incorrect password." };
            }

            user.Username = updatedUser.Username;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;

            var updateSuccess = await _userRepository.UpdateAsync(user);
            if (!updateSuccess)
            {
                return new UpdateUserResultDTO { Success = false, Message = "Failed to update user." };
            }

            return new UpdateUserResultDTO { Success = true, Message = "Your account updated successfully." };
        }

        public async Task<UpdateUserResultDTO> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                return new UpdateUserResultDTO { Success = false, Message = "Old and new passwords are required." };
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null || !_passwordHasher.VerifyPassword(user.Password, oldPassword))
            {
                return new UpdateUserResultDTO { Success = false, Message = "Incorrect old password." };
            }

            user.Password = _passwordHasher.HashPassword(newPassword);
            var updateSuccess = await _userRepository.UpdateAsync(user);
            if (!updateSuccess)
            {
                return new UpdateUserResultDTO { Success = false, Message = "Failed to change password." };
            }

            return new UpdateUserResultDTO { Success = true, Message = "Password changed successfully." };
        }

        public async Task<UpdateUserResultDTO> ActivateUserAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return new UpdateUserResultDTO { Success = false, Message = $"User with ID {userId} not found." };
                }

                if (user.IsActive == ECommerceModels.Enums.IsActive.Active)
                {
                    return new UpdateUserResultDTO { Success = false, Message = "User is already active." };
                }

                user.IsActive = ECommerceModels.Enums.IsActive.Active;
                var updateSuccess = await _userRepository.UpdateAsync(user);
                if (!updateSuccess)
                {
                    return new UpdateUserResultDTO { Success = false, Message = "Failed to activate user." };
                }

                return new UpdateUserResultDTO { Success = true, Message = "User activated successfully." };
            }
            catch (Exception ex)
            {
                return new UpdateUserResultDTO { Success = false, Message = $"Failed to activate user: {ex.Message}" };
            }
        }

        public async Task<UpdateUserResultDTO> DeactivateUserAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return new UpdateUserResultDTO { Success = false, Message = $"User with ID {userId} not found." };
                }

                if (user.IsActive == ECommerceModels.Enums.IsActive.Inactive)
                {
                    return new UpdateUserResultDTO { Success = false, Message = "User is already inactive." };
                }

                user.IsActive = ECommerceModels.Enums.IsActive.Inactive;
                var updateSuccess = await _userRepository.UpdateAsync(user);
                if (!updateSuccess)
                {
                    return new UpdateUserResultDTO { Success = false, Message = "Failed to deactivate user." };
                }

                return new UpdateUserResultDTO { Success = true, Message = "User deactivated successfully." };
            }
            catch (Exception ex)
            {
                return new UpdateUserResultDTO { Success = false, Message = $"Failed to deactivate user: {ex.Message}" };
            }
        }

        public async Task<UpdateUserResultDTO> ChangeRoleAsync(int userId, ECommerceModels.Enums.UserRole newRole)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return new UpdateUserResultDTO { Success = false, Message = $"User with ID {userId} not found." };
                }

                if (user.Role == newRole)
                {
                    return new UpdateUserResultDTO { Success = false, Message = $"User already has the role {newRole}." };
                }

                user.Role = newRole;
                var updateSuccess = await _userRepository.UpdateAsync(user);
                if (!updateSuccess)
                {
                    return new UpdateUserResultDTO { Success = false, Message = "Failed to change user role." };
                }

                return new UpdateUserResultDTO { Success = true, Message = "User role changed successfully." };
            }
            catch (Exception ex)
            {
                return new UpdateUserResultDTO { Success = false, Message = $"Failed to change user role: {ex.Message}" };
            }
        }

        public async Task<UpdateUserResultDTO> UpdateUserWithoutPasswordAsync(int userId, UserDto updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser));
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new UpdateUserResultDTO { Success = false, Message = $"User with ID {userId} not found." };
            }

            user.Username = updatedUser.Username;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;

            var updateSuccess = await _userRepository.UpdateAsync(user);
            if (!updateSuccess)
            {
                return new UpdateUserResultDTO { Success = false, Message = "Failed to update user." };
            }

            return new UpdateUserResultDTO { Success = true, Message = "User updated successfully." };
        }

        private UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                UserID = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                IsActive = user.IsActive,
                DateCreated = user.DateCreated,
                LastLoginDate = user.LastLoginDate
            };
        }
        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user != null ? _mappingService.MapToUserDto(user) : null;
        }
    }
}