using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Services;
using Orders.Infrastructure;
using System.Runtime.CompilerServices;

namespace Orders.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
