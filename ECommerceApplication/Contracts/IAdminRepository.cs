using ECommerceModels.Enums;
using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Contracts
{
     public interface IAdminRepository:IUserRepository
     {
        //Task<List<User>> GetUsersByRoleAsync(UserRole role);
     }

}
