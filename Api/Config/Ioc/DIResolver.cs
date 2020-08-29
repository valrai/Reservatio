using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Reservatio.Services.Business.Customer;

namespace Reservatio.Config.Ioc
{
    public static class DIResolver
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
