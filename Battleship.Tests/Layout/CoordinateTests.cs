using Battleship.CLI.Layout;
using Xunit;

namespace Battleship.Tests.Layout
{
    public class CoordinateTests
    {
        [Fact]
        public void GivenStringShouldConvertToPoint()
        {
            var coordString = "AAAA123";
            
            var coordinate = new Coordinate<string, int>(coordString);

            Assert.Equal("AAAA", coordinate.X);
            Assert.Equal(123, coordinate.Y);
        }

        [Fact]
        public void GivenMalformedStringShouldTryToClean()
        {
            var coordString = "Aa 23";

            var coordinate = new Coordinate<string, int>(coordString);

            Assert.Equal("AA", coordinate.X);
            Assert.Equal(23, coordinate.Y);
        }
    }
}