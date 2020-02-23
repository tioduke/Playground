using Autofac;
using Autofac.Configuration;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WebAPIApplication.Net.Exceptions;

namespace WebAPIApplication.Net
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
            services.AddControllers();

            //Map custom Exceptions to ProblemDetails
            services.AddProblemDetails(setup =>
            {
                setup.Map<TooManyResultsException>(exception => new StatusCodeProblemDetails(TooManyResultsException.Status)
                {
                    Title = TooManyResultsException.Title,
                    Detail = exception.Message
                });
            });
        }

        // This is where you can register things directly with Autofac.
        // It runs after ConfigureServices so the things here will override registrations made in ConfigureServices.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own services within Autofac.
            var module = new ConfigurationModule(Configuration.GetSection("autofac"));
            builder.RegisterModule(module);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseProblemDetails();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
