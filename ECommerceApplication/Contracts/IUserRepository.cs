using EcommercModels;
    
    namespace ECommerceApplication.Contracts
    {
        public interface IUserRepository : IGenericRepository<User>
        {
            public Task<User?> GetByUsername(string username);

            public Task<User?> AuthenticateAsync(string username, string password);
        }
    }