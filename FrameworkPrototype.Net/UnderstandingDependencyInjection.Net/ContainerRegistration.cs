using System;
using Autofac;
using Autofac.Features.AttributeFilters;
using Microsoft.Extensions.DependencyInjection;

using Configuration.Net.Extensions;
using UnderstandingDependencyInjection.Net.Implementation;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net
{
    public class ContainerRegistration
    {
        public static IServiceProvider ConfigureServices()
        {
            var configuration = ConfigUtil.LoadJsonConfig("appsettings.json");

            var builder = new ContainerBuilder();

            builder.ConfigureIOC(configuration, "autofac")
                   .ConfigureOptions<Config>(configuration, "config")
                   .RegisterType<Worker>().As<IWorker>().WithAttributeFiltering();

            return builder.GetServiceProvider();
        }
    }
}
