using System;

namespace MethodInjector.Net
{
    public class Target
    {
        public void Test()
        {
            TargetMethod1();
            Console.WriteLine(TargetMethod2());
            TargetMethod3("Test");
            TargetMethod4();
        }

        private void TargetMethod1()
        {
            Console.WriteLine("Target.TargetMethod1()");

        }

        private string TargetMethod2()
        {
            Console.WriteLine("Target.TargetMethod2()");
            return "Not injected 2";
        }

        public void TargetMethod3(string text)
        {
            Console.WriteLine("Target.TargetMethod3(" + text + ")");
        }

        private void TargetMethod4()
        {
            Console.WriteLine("Target.TargetMethod4()");
        }
    }

}
