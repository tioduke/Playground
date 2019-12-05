using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;

using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using DataAccess.Net.Implementation.Sqlite;
using WebAPIApplication.Net.Entities;
using WebAPIApplication.Net.Filters;
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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add global filters.
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidateModelStateAttribute());
            });

            var currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // Create a container-builder and register dependencies
            var builder = new ContainerBuilder();

            // Populate the service-descriptors added to 'IServiceCollection'
            builder.Populate(services);

            // Register your own things directly with Autofac
            builder.RegisterType<CustomerRepository>().As<IReadableRepository<Customer, CustomerCriteria>>();
            builder.RegisterType<CustomerRepository>().As<IWritableRepository<Customer, CustomerCriteria>>();
            builder.RegisterType<DapperExecutor>().As<IDbExecutor>();
            builder.Register(x => new SqliteAccesDB($"DataSource={currentPath}/Resources/database.sqlite")).As<ICtrlAccesDB>();

            var container = builder.Build();
            return new AutofacServiceProvider(container);
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
