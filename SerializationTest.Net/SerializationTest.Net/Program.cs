using System.Collections.Generic;

namespace SerializationTest.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var obj = new ClassA
            {
                Property1 = new ClassB
                {
                    Property1 = 1,
                    Property2 = "blablabla",
                    Property3 = new List<string> { "uno", "dos" },
                    Property4 = new Dictionary<int, string> { { 42, "valor" } }
                }
            };

            var stream = SerializationUtil.Serialize<ClassA>(obj);
            System.Console.WriteLine(stream.ContentToString());

            var copy = SerializationUtil.Clone<ClassA>(obj);
            System.Console.WriteLine(copy.Equals(obj) ? "Equals" : "Not equals");
        }
    }
}
