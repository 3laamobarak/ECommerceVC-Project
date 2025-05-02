using EcommercModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure
{
    public class ProductRepo : GenericRepo<Product>
    {
        //  private MyProjectContext projectContext;
        public ProductRepo(MyProjectContext context) : base(context)
        {
            //    projectContext = context;
        }
    }

}
