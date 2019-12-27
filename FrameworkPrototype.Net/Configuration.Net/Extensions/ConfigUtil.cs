using System;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuration.Net.Extensions
{
    public static class ConfigUtil
    {
        public static IConfiguration LoadJsonConfig(string jsonConfigPath)
        {
            return new ConfigurationBuilder().AddJsonFile(jsonConfigPath).Build();
        }

        public static IConfiguration LoadXmlConfig(string xmlConfigPath)
        {
            return new ConfigurationBuilder().AddXmlFile(xmlConfigPath).Build();
        }

        public static ContainerBuilder ConfigureIOC(this ContainerBuilder builder, IConfiguration configuration, string sectionName)
        {
            var module = new ConfigurationModule(configuration.GetSection(sectionName));
            builder.RegisterModule(module);

            return builder;
        }

        public static ContainerBuilder ConfigureOptions<T>(this ContainerBuilder builder, IConfiguration configuration, string sectionName) where T : class
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.Configure<T>(configuration.GetSection(sectionName));

            builder.Populate(services);
            return builder;
        }

        public static IServiceProvider GetServiceProvider(this ContainerBuilder builder)
        {
            return new AutofacServiceProvider(builder.Build());
        }
    }
}
