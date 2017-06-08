namespace MethodInjector.Net
{
    public class Program
    {
        static void Main(string[] args)
        {
            Target targetInstance = new Target();

            targetInstance.Test();

            MethodInjector.Install<Target, Injection>("TargetMethod1", "InjectionMethod1");
            MethodInjector.Install<Target, Injection>("TargetMethod2", "InjectionMethod2");
            MethodInjector.Install<Target, Injection>("TargetMethod3", "InjectionMethod3");
            MethodInjector.Install<Target, Injection>("TargetMethod4", "InjectionMethod4");

            targetInstance.Test();

        }
    }
}
