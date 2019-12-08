using System;
using Microsoft.Extensions.Configuration;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;

namespace UnderstandingDependencyInjection.Net
{
    public class ContainerRegistration
    {
        public static IServiceProvider ConfigureServices()
        {
            // Add the configuration to the ConfigurationBuilder.
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            return new AutofacServiceProvider(builder.Build());
        }
    }
}
