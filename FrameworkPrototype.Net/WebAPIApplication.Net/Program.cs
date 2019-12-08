using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    config.AddJsonFile("autofac.json");
                })
                .ConfigureServices(services => services.AddAutofac())
                .UseUrls("http://0.0.0.0:5000/")
                .UseStartup<Startup>();
    }
}
