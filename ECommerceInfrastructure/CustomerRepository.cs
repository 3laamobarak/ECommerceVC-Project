using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        //  private MyProjectContext projectContext;
        public CustomerRepository(MyProjectContext context) : base(context)
        {
            //    projectContext = context;
        }
    }

}
