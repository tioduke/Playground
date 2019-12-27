using System.IO;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;

using Configuration.Net.Extensions;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //setup our DI
            var configuration = ConfigUtil.LoadJsonConfig("appsettings.json");
            var serviceProvider = new ContainerBuilder().ConfigureContainer(configuration, "autofac")
                                                        .ConfigureOptions<Config>(configuration, "config")
                                                        .GetServiceProvider();

            //set the working directory (for the DataSource)
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Directory.SetCurrentDirectory(assemblyDirectory);

            //do the actual work here.
            var worker = serviceProvider.GetService<IWorker>();
            worker.DoSomeWork();
            worker.DoSomeOtherWork();
        }
    }
}
