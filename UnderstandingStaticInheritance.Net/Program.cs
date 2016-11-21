using System;
using System.Collections.Generic;

namespace UnderstandindStaticInheritance.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Before : " + DerivedClass.ListNames.ToDelimitedString());
            DerivedClass.ListNames = new List<string> { "three", "four" };
            Console.WriteLine("After  : " + DerivedClass.ListNames.ToDelimitedString());
        }
    }
}
