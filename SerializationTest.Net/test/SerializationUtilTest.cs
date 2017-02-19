using System.Collections.Generic;
using Xunit;

namespace SerializationTest.Net.Tests
{
    public class SerializationUtilTest
    {       
        [Fact] 
        public void SerializationUtil_AssertObjectSerialization_String() 
        {
            //Arrange
            string str = "Hello, world!";
            
            //Act
            
            //Assert
            SerializationUtilTest.AssertObjectSerialization<string>(str);
        }

        [Fact] 
        public void SerializationUtil_AssertObjectSerialization_ClassA() 
        {
            //Arrange
            ClassA obj = new ClassA
            {
                Property1 = new ClassB
                {
                    Property1 = 1,
                    Property2 = "blablabla",
                    Property3 = new List<string> { "uno", "dos" },
                    Property4 = new Dictionary<string, object> { { "clave", "valor" } } 
                } 
            };
            
            //Act
            
            //Assert
            SerializationUtilTest.AssertObjectSerialization<ClassA>(obj);
        }

        public static void AssertObjectSerialization<T>(T source)
        {
            T copy = SerializationUtil.Clone<T>(source);

            Assert.True(copy.Equals(source));
        }

    }
}
