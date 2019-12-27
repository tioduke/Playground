using System;
using Microsoft.Extensions.Configuration;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;

namespace Configuration.Net.Extensions
{
    public static class ConfigUtil
    {
        public static IConfiguration LoadJsonConfig(string jsonConfigPath)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile(jsonConfigPath);

            return config.Build();
        }

        public static IConfiguration LoadXmlConfig(string xmlConfigPath)
        {
            var config = new ConfigurationBuilder();
            config.AddXmlFile(xmlConfigPath);

            return config.Build();
        }

        public static IServiceProvider ConfigureContainer(this IConfiguration configuration, string sectionName)
        {
            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(configuration.GetSection(sectionName));
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            return new AutofacServiceProvider(builder.Build());
        }
    }
}
