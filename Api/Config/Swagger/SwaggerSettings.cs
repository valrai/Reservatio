using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Reservatio.Config.Swagger
{
    public static class SwaggerSettings
    {
        public static void SetSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {

                #region Api info

                var apiinfo = new OpenApiInfo
                    {
                        Title = "Reservatio",
                        Version = "v1",
                        Description = "Api da aplicação Reservatio",
                        Contact = new OpenApiContact
                        {
                            Name = "Valdecir Raimundo",
                            Url = new Uri("https://github.com/valrai/Reservatio")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "MIT",
                            Url = new Uri("https://github.com/valrai/Reservatio/blob/master/LICENSE")
                        }
                    };

                #endregion

                #region Security Definition

                var securityDefinition = new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    Description = "Specify the authorization token. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                };

                #endregion

                #region Xml Path

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                #endregion

                #region Security Requirements

                OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                };

                #endregion

                options.SwaggerDoc("v1", apiinfo);
                options.IncludeXmlComments(xmlPath);
                options.AddSecurityDefinition("Bearer", securityDefinition);
                options.AddSecurityRequirement(securityRequirements);
            });
        }
    }
}
