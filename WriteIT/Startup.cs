using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using WriteIT.Data;
using WriteIT.Mappers;
using WriteIT.Services;

namespace WriteIT
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(WriteITProfile));
            services.AddScoped<WriteITContext>();
            services.AddScoped<MovieService>();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = Path.Join(env.ContentRootPath, "clientapp");
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
