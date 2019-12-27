using System;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

using Configuration.Net.Extensions;

namespace UnderstandingDependencyInjection.Net
{
    public class ContainerRegistration
    {
        public static IServiceProvider ConfigureServices()
        {
            var configuration = ConfigUtil.LoadJsonConfig("appsettings.json");

            var builder = new ContainerBuilder();
            return builder.ConfigureContainer(configuration, "autofac")
                          .ConfigureOptions<Config>(configuration, "config")
                          .GetServiceProvider();

        }
    }
}
