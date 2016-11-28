using System;
using System.Collections.Generic;

namespace UnderstandingExtensionMethods.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var liste = new List<int> { 50, 51 };
            Console.WriteLine("Liste<int> = { " + liste.ToDelimitedString() + " }");

            var critrRech = new Criteres(new DateTime(2011, 1, 1), new DateTime(2012, 2, 2), 50, 51);
            Console.WriteLine("Criteres 1 = { " + critrRech.ToParamArray().ToDelimitedString() + " }");

            var critrRech2 = new Criteres(new DateTime(2011, 1, 1), new DateTime(2012, 2, 2));
            Console.WriteLine("Criteres 2 = { " + critrRech2.ToParamArray().ToDelimitedString() + " }");

            var aClass = SealedClassExtensions.CreateInstance("one");
            var liste2 = aClass.GetListeString();
            Console.WriteLine("Liste<string> = { Count = " + liste2.Count + ", Value(s) = " + liste2.ToDelimitedString() + " }");
        }
    }
}
