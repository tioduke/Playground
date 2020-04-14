using System;
using System.Text;
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

        [Fact]
        public void ConvertToString_ValueLessThanZero_ConversionOK()
        {
            //Arrange
            var value = -12.34m;

            //Act
            var result = ConvertToString(value);

            //Assert
            Assert.Equal("00000000000001234-", result);
        }

        [Fact]
        public void ConvertToString_ValueLessThanZeroAndFloored_ConversionOK()
        {
            //Arrange
            var value = -12.346m;

            //Act
            var result = ConvertToString(value);

            //Assert
            Assert.Equal("00000000000001234-", result);
        }

        [Fact]
        public void ConvertToString_ValueLGreaterThanZero_ConversionOK()
        {
            //Arrange
            var value = +12.34m;

            //Act
            var result = ConvertToString(value);

            //Assert
            Assert.Equal("00000000000001234+", result);
        }

        [Fact]
        public void ConvertToString_ValueLGreaterThanZeroAndFloored_ConversionOK()
        {
            //Arrange
            var value = +12.346m;

            //Act
            var result = ConvertToString(value);

            //Assert
            Assert.Equal("00000000000001234+", result);
        }

        private string ConvertToString(decimal value)
        {
            return new StringBuilder()
                .Append(Convert.ToString(Math.Floor(Math.Abs(value * 100))))
                .Append(value < 0.0m ? "-" : "+").ToString().PadLeft(18, '0');
        }
    }
}
