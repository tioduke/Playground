using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Configuration;

using WebAPIApplication.Net.Filters;

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

            // Add global filters.
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidateModelStateFilter());
            });
        }

        // This is where you can register things directly with Autofac.
        // It runs after ConfigureServices so the things here will override registrations made in ConfigureServices.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own services within Autofac.
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
