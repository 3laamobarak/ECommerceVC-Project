using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure
{
    public class CustomerRepositpory : GenericRepositpory<Customer>
    {
        //  private MyProjectContext projectContext;
        public CustomerRepositpory(MyProjectContext context) : base(context)
        {
            //    projectContext = context;
        }
    }

}
