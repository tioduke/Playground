using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;

namespace WebAPIApplication.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //set the working directory (for the DataSource)
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddXmlFile("appsettings.xml");
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
