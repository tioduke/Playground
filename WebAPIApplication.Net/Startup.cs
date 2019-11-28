using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add application services.
            services.AddScoped<IReadableRepository<Customer, CustomerCriteria>, CustomerRepository>()
                    .AddScoped<IWritableRepository<Customer, CustomerCriteria>, CustomerRepository>()
                    .AddScoped<IDbExecutor, DapperExecutor>()
                    .AddScoped<ICtrlAccesDB>(x => new SqliteAccesDB("DataSource=Resources/database.sqlite"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
