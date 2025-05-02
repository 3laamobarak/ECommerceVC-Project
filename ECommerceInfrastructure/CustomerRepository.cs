using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure
{
    public class Repositpory : GenericRepositpory<Product>
    {
        //  private MyProjectContext projectContext;
        public Repositpory(MyProjectContext context) : base(context)
        {
            //    projectContext = context;
        }
    }

}
