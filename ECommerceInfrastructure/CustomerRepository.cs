using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceContext;

namespace ECommerceInfrastructure
{
    public class CustomerRepositpory : GenericRepository<Customer>
    {
        private AppDBContext _context;
        public CustomerRepositpory(AppDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
