using ECommerceApplication.Contracts;
using ECommerceApplication.PasswordHasherService;
using ECommerceApplication.Validators;
using ECommerceDTOs;
using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Services.AuthServices
{

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthRepository _authRepository;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _authRepository = authRepository;
        }
        public async Task<ValidationResultDTO> RegisterAsync(RegisterUserDto dto)
        {
            var result = GenericValidator.Validate(dto);

            if (!result.Success)
                return result;

            if (await _authRepository.UsernameExistsAsync(dto.Username))
            {
                result.Success = false;
                AddError(result, "Username", "Username is already taken.");
            }

            if (await _authRepository.EmailExistsAsync(dto.Email))
            {
                result.Success = false;
                AddError(result, "Email", "Email is already registered.");
            }

            if (!result.Success)
                return result;

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = UserRole.Client,

                Username = dto.Username,
                Email = dto.Email,
                Password = _passwordHasher.HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user);
            result.Success = true;
            return result;
        }
        private void AddError(ValidationResultDTO result, string field, string message)
        {
            if (!result.Errors.ContainsKey(field))
                result.Errors[field] = new List<string>();
            result.Errors[field].Add(message);
        }
        public async Task<LoginResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(loginDto.UsernameOrEmail);
            if (user == null || !_passwordHasher.VerifyPassword(user.Password, loginDto.Password))
            {
                return new LoginResultDto { Success = false, Message = "Invalid credentials" };
            }
            if (user.IsActive == IsActive.Inactive)
            {
                return new LoginResultDto { Success = false, Message = "Your Account Is IN Active" };
            }

            await _userRepository.UpdateLastLoginDateAsync(user.Id, DateTime.Now);
            var sessionUser = new SessionUserDto
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };

            SessionManager.SetSession(sessionUser);

            return new LoginResultDto { Success = true, Message = "Login successful" };
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

        public async Task<ValidationResultDTO> UpdateUserAsync(UpdateUserDTO dto)
        {

            var result = GenericValidator.Validate(dto);

            if (!result.Success)
                return result;

            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null || !_passwordHasher.VerifyPassword(user.Password, dto.Password))
            {
                result.Success = false;
                AddError(result, "Password", "INCorrect Password  .");

            }

            if (await _authRepository.UsernameExistsAsync(dto.Username, dto.UserId))
            {
                result.Success = false;
                AddError(result, "Username", "Username is already taken by another user .");
            }

            if (await _authRepository.EmailExistsAsync(dto.Email, dto.UserId))
            {
                result.Success = false;
                AddError(result, "Email", "Email is already registered by another user .");
            }

            if (!result.Success)
                return result;

            var sessionUser = new SessionUserDto
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };



            user.Username = dto.Username;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;

            var updateSuccess = await _userRepository.UpdateAsync(user);
            if (updateSuccess)
            {
                result.Success = true;
                SessionManager.SetSession(sessionUser);


            }




            return result;

        }














    }
}
