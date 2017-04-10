using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using treinoAppCore.Services;

namespace treinoAppCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logFactory)
        {
            logFactory
                .AddConsole()
                .AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvcWithDefaultRoute();
             
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
            

            app.Run(context => {
                return context.Response.WriteAsync("Asp.Net Core in execution");
            });
        }
    }
}