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
            System.out.println("Before : " + DerivedClass.ListNames);
            DerivedClass.ListNames = new List<string> { "three", "four" };
            System.out.println("After  : " + DerivedClass.ListNames);
        }
    }
}
