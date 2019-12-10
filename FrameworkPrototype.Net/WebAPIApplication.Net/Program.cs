using System.IO;
using System.Reflection;
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
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Directory.SetCurrentDirectory(assemblyDirectory);

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
                    config.AddJsonFile("autofac.json");
                    config.AddJsonFile("appsettings.json");
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
