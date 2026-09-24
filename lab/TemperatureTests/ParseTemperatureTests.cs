using Xunit;
using lab;

namespace TemperatureTests
{
    public class ParseTemperatureTests
    {
        [Fact]
        public void CorrectAirLine_CreatesAirTemperature()
        {
            string input = "air 2026.09.23 \"Центр города\" 18.5 10 20 2";
            var parser = new ParseTemperature(input);
            Assert.True(parser.ReadyToUse);
            AirTemperature temperature = Assert.IsType<AirTemperature>(parser.Temperature);
            Assert.Equal(input, temperature.ToString());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("unknown 2026.09.23 \"Город\" 18.5 10 20 2")]
        [InlineData("air 2026.02.30 \"Город\" 18.5 10 20 2")]
        [InlineData("air 2026.09.23 Город 18.5 10 20 2")]
        [InlineData("air 2026.09.23 \"Город\" abc 10 20 2")]
        [InlineData("air 2026.09.23 \"Город\" 18.5 10 20 -2")]
        public void IncorrectLine_IsRejected(string? input)
        {
            var parser = new ParseTemperature(input);
            Assert.False(parser.ReadyToUse);
            Assert.Null(parser.Temperature);
        }
    }
}