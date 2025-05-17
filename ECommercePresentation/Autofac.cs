using Autofac;
using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceApplication.PasswordHasherService;
using ECommerceApplication.Services.AuthServices;
using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.ProductService;
using ECommerceApplication.Services.UserServices;
using ECommerceContext;
using ECommerceInfrastructure;
using ECommerceInfrastructure.Security;
using ECommercePresentation.AuthForms;
using ECommercePresentation.Client;

namespace ECommercePresentation
{
    public class Autofac
    {
        public static IContainer Inject()
        {
            var builder = new ContainerBuilder();

            // Register DbContext
            builder.RegisterType<AppDBContext>().AsSelf().InstancePerLifetimeScope();

            // Register Repositories
            builder.RegisterType<AuthRepository>().As<IAuthRepository>().InstancePerDependency();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerDependency();
            builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerDependency();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>().InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();

            // Register Services
            builder.RegisterType<MappingService>().As<IMappingService>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerDependency();
            builder.RegisterType<OrderDetailService>().As<IOrderDetailService>().InstancePerDependency();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerDependency();
            builder.RegisterType<CartItemService>().As<ICartItemService>().InstancePerDependency();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().InstancePerDependency();

            // Register Forms
            builder.RegisterType<LoginForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<RegistrationForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<Base>().AsSelf().InstancePerDependency();
            builder.RegisterType<CategoryForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<OrderForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<ProductForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<CartItemForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<ClientOrder>().AsSelf().InstancePerDependency();
            builder.RegisterType<ProductDashboardForm>().AsSelf().InstancePerDependency();
            //builder.RegisterType<ProductDetailForm>().AsSelf().InstancePerDependency();


            // Build the container
            var container = builder.Build();

            return container;
        }
    }
}