using Autofac;
using ECommerceApplication.Contracts;
using ECommerceContext;
using ECommerceInfrastructure;

namespace ECommercePresentation
{
    public class Autofac
    {
        public static IContainer Inject()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AppDBContext>().As<AppDBContext>();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            
            var container = builder.Build();

            return container;
        }
    }
}