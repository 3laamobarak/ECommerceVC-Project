using ECommerceApplication.Contracts;
using ECommerceApplication.PasswordHasherService;
using ECommerceApplication.Validators;
using ECommerceDTOs;
using ECommerceModels.Enums;
using EcommercModels;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ECommerceApplication.Services.AuthServices
{

    public class AuthService: IAuthService
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
        public async Task<RegistrationResultDTO> RegisterAsync(RegisterUserDto dto)
        {
            var result = RegisterUserValidator.Validate(dto);
            result.RegisterationUserData = dto;
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
        private void AddError(RegistrationResultDTO result, string field, string message)
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
    }
}
