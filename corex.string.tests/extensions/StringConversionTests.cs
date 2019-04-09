using System;
using Xunit;
using corex.@string.extensions;

namespace corex.@string.tests.extensions
{
    public class StringConversionTests
    {
        [Theory]
        [InlineData("-128",                     SByte.MinValue)]
        [InlineData("127",                      SByte.MaxValue)]
        [InlineData("0",                        byte.MinValue)]
        [InlineData("255",                      byte.MaxValue)]
        [InlineData("-32768",                   short.MinValue)]
        [InlineData("32767",                    short.MaxValue)]
        [InlineData("0",                        ushort.MinValue)]
        [InlineData("65535",                    ushort.MaxValue)]
        [InlineData("-2147483648",              int.MinValue)]
        [InlineData("2147483647",               int.MaxValue)]
        [InlineData("0",                        uint.MinValue)]
        [InlineData("4294967295",               uint.MaxValue)]
        [InlineData("-9223372036854775808",     long.MinValue)]
        [InlineData("9223372036854775807",      long.MaxValue)]
        [InlineData("0",                        ulong.MinValue)]
        [InlineData("18446744073709551615",     ulong.MaxValue)]
        [InlineData("3.14159",                  3.14159f)]
        [InlineData("-3.14159",                 -3.14159f)]
        [InlineData("3.14159",                  3.14159D)]
        [InlineData("-3.14159",                 -3.14159D)]
        [InlineData("true",                     true)]
        [InlineData("false",                    false)]
        [InlineData("x",                        'x')]
        public void CallingTo_WithValidInputString_ReturnsValidOutput<T>(string input, T expectedOutput)
            => Assert.Equal(expectedOutput, input.To<T>());
        
        [Fact]
        public void CallingTo_WithNullInputString_ThrowsException()
            => Assert.Throws<InvalidCastException>(() => StringConversion.To<bool>(null));

        [Fact]
        public void CallingTo_WithInvalidFormatInputString_ThrowsException()
            => Assert.Throws<FormatException>(() => "hello".To<int>());

        [Fact]
        public void CallingTo_WithOverflowFormatInputString_ThrowsException()
            => Assert.Throws<OverflowException>(() => "9223372036854775807".To<int>());

        [Theory]
        [InlineData("true", false, true)]
        [InlineData("5.0", 10.0D, 5.0D)]
        [InlineData("0.2", 0.1f, 0.2f)]
        [InlineData("123", 0, 123)]
        public void CallingTo_WithValidInputStringAndDefaultValue_ReturnsValidOutputAndNotDefaultValue<T>(string input, T defaultValue, T expectedOutput)
            => Assert.Equal(expectedOutput, input.To<T>(defaultValue));

        [Theory]
        [InlineData(null, false)]
        [InlineData("", 10.0D)]
        [InlineData("hello", 0.1f)]
        [InlineData("9223372036854775807", -1)]
        public void CallingTo_WithInvalidInputStringAndDefaultValue_ReturnsDefaultValue<T>(string input, T defaultValue)
            => Assert.Equal(defaultValue, input.To<T>(defaultValue));
    }
}