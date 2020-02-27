using System.Threading.Tasks;

namespace UnderstandingDependencyInjection.Net.Interfaces
{
    public interface IWorker
    {
        Task DoSomeWork();
        Task DoSomeOtherWork();
    }
}