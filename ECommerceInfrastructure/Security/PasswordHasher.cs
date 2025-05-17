using ECommerceApplication.PasswordHasherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCrypt.Net;
using System.Threading.Tasks;
namespace ECommerceInfrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string plainPassword)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(plainPassword);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            return HashPassword(plainPassword) == hashedPassword;
        }
    }
}