using Microsoft.Extensions.DependencyInjection;

namespace Reservatio.Config.Cors
{
    public static class CorsSettings
    {
        public static void SetCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(origin => true)
                        .AllowCredentials());
            });
        }
    }
}
