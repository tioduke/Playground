using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderstandindStaticInheritance.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Before : " + DerivedClass.ListNames[0]);
            DerivedClass.ListNames = new List<string> { "three", "four" };
            Console.WriteLine("After  : " + DerivedClass.ListNames[0]);
        }
    }
}
