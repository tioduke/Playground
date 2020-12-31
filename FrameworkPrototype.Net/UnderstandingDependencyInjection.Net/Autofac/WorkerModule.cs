using Autofac;

using UnderstandingDependencyInjection.Net.Implementation;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Autofac
{
    public class WorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerStrategy>().As<ICustomerStrategy>().AsSelf();
            builder.RegisterType<OtherCustomerStrategy>().As<ICustomerStrategy>().AsSelf();

            builder.Register(ctx => new Worker(ctx.Resolve<CustomerStrategy>(), ctx.Resolve<OtherCustomerStrategy>()))
                .As<IWorker>();
        }
    }
}