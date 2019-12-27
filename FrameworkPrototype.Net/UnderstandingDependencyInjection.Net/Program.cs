using System.IO;
using System.Reflection;
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
            var serviceProvider = ConfigUtil.LoadJsonConfig("appsettings.json")
                                            .ConfigureContainer("autofac");

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
