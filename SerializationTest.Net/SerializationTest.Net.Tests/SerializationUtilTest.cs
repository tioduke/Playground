using AutoFixture;
using Xunit;

namespace SerializationTest.Net.Tests
{
    public class SerializationUtilTest
    {
        private readonly Fixture _fixture;

        public SerializationUtilTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Clone_ObjectIsString_CopyAndObjectAreEqual()
        {
            //Arrange
            string str = _fixture.Create<string>();

            //Act
            var copy = SerializationUtil.Clone(str);

            //Assert
            Assert.Equal(str, copy);
        }

        [Fact]
        public void Clone_ObjectIsClassA_CopyAndObjectAreEqual()
        {
            //Arrange
            var obj = _fixture.Create<ClassA>();

            //Act
            var copy = SerializationUtil.Clone(obj);

            //Assert
            Assert.Equal(obj, copy);
        }
    }
}
