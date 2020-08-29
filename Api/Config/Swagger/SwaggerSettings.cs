using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Reservatio.Config.Swagger
{
    public static class SwaggerSettings
    {
        public static void SetSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Reservatio",
                        Version = "v1",
                        Description = "Api da aplicação Reservatio",
                        Contact = new OpenApiContact
                        {
                            Name = "Valdecir Raimundo",
                            Url = new Uri("https://github.com/valrai/Reservatio")
                        }

                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
