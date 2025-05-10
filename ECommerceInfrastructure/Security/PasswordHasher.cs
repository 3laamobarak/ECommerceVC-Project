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
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}