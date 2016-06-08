using System.Collections.Generic;

namespace SerializationTest.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "Hello, world!";
            SerializationUtil.AssertObjectSerialization<string>(str);

            var obj = new ClassA
            {
                Property1 = new ClassB
                {
                    Property1 = 1,
                    Property2 = "blablabla",
                    Property3 = new List<string> { "uno", "dos" },
                    Property4 = new Dictionary<string, object> { { "clave", "valor" } } 
                } 
            };
            SerializationUtil.AssertObjectSerialization<ClassA>(obj);
        }
    }
}
