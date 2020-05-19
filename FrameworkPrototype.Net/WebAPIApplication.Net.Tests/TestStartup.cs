using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTested.AspNetCore.Mvc;

using DataAccess.Net.Implementation;
using DataAccess.Net.Implementation.Sqlite;
using DataAccess.Net.Interfaces;
using WebAPIApplication.Net.Entities;
using WebAPIApplication.Net.Repositories;

namespace WebAPIApplication.Net.Tests
{
    public class TestStartup : Startup
    {
        // Prepare additional server configuration - add AutoFac here.
        // Call 'IsRunningOn' either in the static constructor of the TestStartup class
        // or in an assembly initialization method if your test runner supports it.
        // Note that 'IsRunningOn' should be called only once per test project.
        static TestStartup()
            => MyApplication
                .IsRunningOn(server => server
                    .WithServices(services => services.AddAutofac()));

        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            // Call the base ConfigureServices method to register all your web application services.
            base.ConfigureServices(services);

            // Add the 'MyTested.AspNetCore.Mvc' testing infrastructure afterward.
            // For API scenarios without views.
            services.AddControllersTesting();

            // Replace all services which need to be mocked in the service collection.
        }

        public void ConfigureTestContainer(ContainerBuilder builder)
        {
            // Call the base ConfigureContainer method to register all your application container services.
            base.ConfigureContainer(builder);

            // Replace all services which need to be mocked in the container.
            builder.RegisterInstance(new SqliteCtrlAccesDB("bidon")).As<ICtrlAccesDB>();
            builder.RegisterType<DapperExecutor>().As<IDbExecutor>();
            builder.RegisterType<CustomerRepository>().As<IReadableRepository<Customer, CustomerCriteria>>();
            builder.RegisterType<CustomerRepository>().As<IWritableRepository<Customer, CustomerCriteria>>();
        }
    }
}