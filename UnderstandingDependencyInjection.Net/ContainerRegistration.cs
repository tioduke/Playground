using System;
using Microsoft.Extensions.DependencyInjection;

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
            return new ServiceCollection()
                .AddScoped<IWorker, Worker>()
                .AddScoped<IReadableRepository<Customer>, CustomerRepository>()
                .AddScoped<IReadableRepository<Customer, CustomerCriteria>, CustomerRepository>()
                .AddScoped<IDbExecutor, DapperExecutor>()
                .AddScoped<ICtrlAccesDB>(x => new SqliteCtrlAccesDB("DataSource=Resources/database.sqlite"))
                .BuildServiceProvider();
        }
    }
}
