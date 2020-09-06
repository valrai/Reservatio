using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Reservatio.Config.Api
{
    public static class ApiSettings
    {
        public static void SetApiBehaviorOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory =
                    context => new ConflictObjectResult(context.ModelState);
            });
        }
    }
}
