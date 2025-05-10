//using ECommerceApplication.Contracts;
//using ECommerceModels.Enums;
//using EcommercModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ECommerceDTOs;
//using ECommerceApplication.PasswordHasherService;

//namespace ECommerceApplication.Services.UserServices
//{
//    public class UserService : IUserService
//    {
//        private readonly IAdminRepository _userRepository;
//        private readonly IPasswordHasher _passwordHasher;

//        public UserService(IAdminRepository userRepository, IPasswordHasher passwordHasher)
//        {
//            _userRepository = userRepository;
//            _passwordHasher = passwordHasher;
//        }

//        public async Task RegisterUserAsync(RegisterUserDto newUser, string password)
//        {
//            var user = await _userRepository.GetByUsernameOrEmailAsync(newUser.Username);
//            if (user != null)
//            {
                 
//            }
//            user = 
//            var user = new User()
//            {
//                Role = newUser.Role,
//                IsActive = IsActive.Active,
//                Password = _passwordHasher.HashPassword(password)

//            };
//             await _userRepository.AddAsync(user);
//        }
//        //login by username 
       
//        public async Task<User> LoginAsync(string identifier, string password)
//        {
//            var user = await _userRepository.GetByUsernameOrEmailAsync(identifier);
//            if (user == null || !_passwordHasher.VerifyPassword(user.Password, password))
//                return null;

//            return user;
//        }
//        public async Task<User> LoginByEmailAsync(string email, string password)
//        {
//            var user = await _userRepository.GetByUsernameAsync(email);
//            if (user == null || !_passwordHasher.VerifyPassword(user.Password, password))
//                return null;

//            return user;
//        }

//        public async Task<User> GetUserDetailsAsync(int userId)
//        {
//            return await _userRepository.GetByIdAsync(userId);
//        }

//        //public async Task UpdateUserAsync(User updatedUser, string newPassword = null)
//        //{
//        //    var user = await _userRepository.GetByIdAsync(updatedUser.Id);
//        //    if (user == null) throw new Exception("User not found");

//        //    user.Name = updatedUser.Name;
//        //    user.Username = updatedUser.Username;

//        //    if (!string.IsNullOrEmpty(newPassword))
//        //        user.PasswordHash = _passwordHasher.HashPassword(newPassword);

//        //    await _userRepository.UpdateAsync(user);
//        //}
//    }

//}
