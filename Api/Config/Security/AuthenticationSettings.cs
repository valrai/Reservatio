using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Reservatio.Config.Security
{
    public static class AuthenticationSettings
    {
        public static void SetAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/reservatio-c2771";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/reservatio-c2771",
                        ValidateAudience = true,
                        ValidAudience = "reservatio-c2771",
                        ValidateLifetime = true
                    };
                });
        }
    }
}
