using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using DataAccess.Net.Implementation.Sqlite;
using WebAPIApplication.Net.Entities;
using WebAPIApplication.Net.Repositories;

namespace WebAPIApplication.Net
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add application services.
            services.AddScoped<IReadableRepository<Customer, CustomerCriteria>, CustomerRepository>()
                    .AddScoped<IWritableRepository<Customer, CustomerCriteria>, CustomerRepository>()
                    .AddScoped<IDbExecutor, DapperExecutor>()
                    .AddScoped<ICtrlAccesDB>(x => new SqliteCtrlAccesDB("DataSource=Resources/database.sqlite"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
