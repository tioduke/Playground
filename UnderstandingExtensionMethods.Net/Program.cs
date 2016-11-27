using System;
using System.Collections.Generic;

namespace UnderstandingExtensionMethods.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int> { 50, 51 };
            Console.WriteLine(list.ToDelimitedString());
            Console.ReadLine();

            var critrRech = new Criteres(new DateTime(2011, 1, 1), new DateTime(2012, 2, 2), 50, 51);
            Console.WriteLine(critrRech.ToParamArray().ToDelimitedString());
            Console.ReadLine();

            var critrRech2 = new Criteres(new DateTime(2011, 1, 1), new DateTime(2012, 2, 2));
            Console.WriteLine(critrRech2.ToParamArray().ToDelimitedString());
            Console.ReadLine();

            var aClass = SealedClassExtensions.CreateInstance("one");
            var lStr = aClass.GetListeString();
            Console.WriteLine(lStr.Count + " " + lStr[0]);
            Console.ReadLine();
        }
    }
}
