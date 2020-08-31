using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Reservatio.Data.Repositories;
using Reservatio.Services.Business.Customer;
using Reservatio.Services.User;

namespace Reservatio.Config.Ioc
{
    public static class DIResolver
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IUserService, UserService>();

            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
