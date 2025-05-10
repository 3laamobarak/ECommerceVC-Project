using Autofac;
using ECommerceApplication.Contracts;
using ECommerceApplication.Mapping;
using ECommerceApplication.PasswordHasherService;
using ECommerceApplication.Services.AuthServices;
using ECommerceApplication.Services.CartItemService;
using ECommerceApplication.Services.CategoryService;
using ECommerceApplication.Services.IOrderDetailsService;
using ECommerceApplication.Services.ProductService;
using ECommerceContext;
using ECommerceInfrastructure;
using ECommerceInfrastructure.Security;
using ECommercePresentation.AuthForms;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePresentation;

static class Program
{
    private static IContainer _container;

    [STAThread]
    static void Main()
    {
        _container = Autofac.Inject();

        ApplicationConfiguration.Initialize();
        using (var scope = _container.BeginLifetimeScope())
        {
            // Resolve the form and run it
            var loginForm = scope.Resolve<LoginForm>();
            Application.Run(loginForm);
        }
    }
    public static T Resolve<T>()
    {
        return _container.Resolve<T>();
    }
}