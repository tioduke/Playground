using System;

namespace MethodInjector.Net
{
    public class Injection
    {        
        private void InjectionMethod1()
        {
            Console.WriteLine("Injection.InjectionMethod1()");
        }

        private string InjectionMethod2()
        {
            Console.WriteLine("Injection.InjectionMethod2()");
            return "Injected 2";
        }

        private void InjectionMethod3(string text)
        {
            Console.WriteLine("Injection.InjectionMethod3(" + text + ")");
        }

        private void InjectionMethod4()
        {
            System.Diagnostics.Process.Start("kcalc");
        }
    }

}
