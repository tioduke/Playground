using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //setup our DI
            var serviceProvider = ContainerRegistration.ConfigureServices();

            //set the working directory (for the DataSource)
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Directory.SetCurrentDirectory(assemblyDirectory);

            //do the actual work here.
            var worker = serviceProvider.GetService<IWorker>();
            await worker.DoSomeWork();
            await worker.DoSomeOtherWork();
        }
    }
}
