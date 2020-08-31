using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservatio.Config.Cors;
using Reservatio.Config.Data;
using Reservatio.Config.Ioc;
using Reservatio.Config.Localization;
using Reservatio.Config.Middlewares;
using Reservatio.Config.Security;
using Reservatio.Config.Swagger;

namespace Reservatio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.SetLocalization();
            services.SetCorsPolicy();
            services.SetDbConnection(Configuration);
            services.AddControllers();
            services.SetSwagger();
            services.RegisterServices();
            services.SetAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                ErrorHandlingMiddleware.IsDevelopment = true;
            }

            app.UseCors("CorsPolicy");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reservatio - V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
