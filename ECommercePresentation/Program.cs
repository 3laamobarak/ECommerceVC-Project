using Autofac;
using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.ProductService;
using ECommerceContext;
using ECommerceInfrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePresentation;

static class Program
{
    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddDbContext<AppDBContext>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IMappingService, MappingService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICartItemService, CartItemService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();

        
        ApplicationConfiguration.Initialize();
        var provider = services.BuildServiceProvider();
        Application.Run(new LoginForm());
        //Application.Run(new BaseForm(provider.GetRequiredService<IProductService>(), provider.GetRequiredService<ICategoryService>(), provider.GetRequiredService<ICartItemService>(), provider.GetRequiredService<IOrderService>()));
        
    }
}