using ECommerceApplication.Contracts;
  using ECommerceApplication.PasswordHasherService;
  using ECommerceDTOs;
  using EcommercModels;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;

  namespace ECommerceApplication.Services.UserServices
  {
      public class UserService : IUserService
      {
          private readonly IUserRepository _userRepository;
          private readonly IPasswordHasher _passwordHasher;

          public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
          {
              _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
              _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
          }

          /// <summary>
          /// Retrieves all users as a list of UserDto objects.
          /// </summary>
          /// <returns>An enumerable of UserDto objects.</returns>
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

          /// <summary>
          /// Retrieves detailed information for a specific user by their ID.
          /// </summary>
          /// <param name="userId">The ID of the user to retrieve.</param>
          /// <returns>A UserDetailDTO containing the user's details.</returns>
          /// <exception cref="KeyNotFoundException">Thrown if the user is not found.</exception>
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
                  LastName = user.LastName
              };
          }

          /// <summary>
          /// Updates a user's details after verifying their password.
          /// </summary>
          /// <param name="userId">The ID of the user to update.</param>
          /// <param name="updatedUser">The updated user details.</param>
          /// <param name="password">The user's current password for verification.</param>
          /// <returns>An UpdateUserResultDTO indicating the result of the update operation.</returns>
          public async Task<UpdateUserResultDTO> UpdateUserAsync(int userId, UserDetailDTO updatedUser, string password)
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

          /// <summary>
          /// Changes a user's password after verifying the old password.
          /// </summary>
          /// <param name="userId">The ID of the user to update.</param>
          /// <param name="oldPassword">The user's current password.</param>
          /// <param name="newPassword">The new password to set.</param>
          /// <returns>An UpdateUserResultDTO indicating the result of the password change.</returns>
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

          /// <summary>
          /// Maps a User entity to a UserDto.
          /// </summary>
          /// <param name="user">The User entity to map.</param>
          /// <returns>A UserDto containing the user's details.</returns>
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
      }
  }