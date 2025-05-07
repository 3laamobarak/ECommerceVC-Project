using Autofac;
using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceContext;
using ECommerceInfrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePresentation;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //var container = Autofac.Inject();
        //To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        //ApplicationConfiguration.Initialize();



        var services = new ServiceCollection();
        services.AddDbContext<AppDBContext>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IMappingService, MappingService>();


        ApplicationConfiguration.Initialize();
        var provider = services.BuildServiceProvider();
        Application.Run(new OrderForm(provider.GetRequiredService<IOrderService>())); 
        
    }
}