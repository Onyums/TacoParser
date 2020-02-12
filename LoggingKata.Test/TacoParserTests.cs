using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("30.056, -69.6969, A name...")]
        public void ShouldParse(string str)
        {
            var tacoTest = new TacoParser();
            var test = tacoTest.Parse(str);
            Assert.IsType<TacoBell>(test);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("30, Name")]
        public void ShouldFailParse(string str)
        {
            var tester = new TacoParser();
            var test = tester.Parse(str);
            Assert.Null(test);
        }
    }
}
