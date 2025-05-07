using EcommercModels;
using ECommerceContext;
using ECommerceModels.Enums;
using Microsoft.EntityFrameworkCore;
using ECommerceApplication.Contracts;

namespace ECommerceInfrastructure
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }

        // Find a user by username
        public async Task<User?> GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        // Find a user by email
        public async Task<User?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Username or password cannot be null or empty");
            }

            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        // Get all active users
        public async Task<IQueryable<User>> GetActiveUsersAsync()
        {
            return await Task.FromResult(
                _context.Users
                    .AsNoTracking()
                    .Where(c=>c.IsActive == IsActive.Active)
            );
        }
    }
}