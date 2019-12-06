using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;

using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using DataAccess.Net.Implementation.Sqlite;
using UnderstandingDependencyInjection.Net.Entities;
using UnderstandingDependencyInjection.Net.Implementation;
using UnderstandingDependencyInjection.Net.Interfaces;
using UnderstandingDependencyInjection.Net.Repositories;

namespace UnderstandingDependencyInjection.Net
{
    public class ContainerRegistration
    {
        public static IServiceProvider ConfigureServices()
        {
            // Create a container-builder and register dependencies
            var builder = new ContainerBuilder();

            // Register your own things directly with Autofac
            builder.RegisterType<Worker>().As<IWorker>();
            builder.RegisterType<CustomerRepository>().As<IReadableRepository<Customer>>();
            builder.RegisterType<CustomerRepository>().As<IReadableRepository<Customer, CustomerCriteria>>();
            builder.RegisterType<DapperExecutor>().As<IDbExecutor>();
            var currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            builder.Register(x => new SqliteAccesDB($"DataSource={currentPath}/Resources/database.sqlite")).As<ICtrlAccesDB>();

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
