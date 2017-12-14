using Battleship.CLI.Ships;
using Moq;
using Xunit;

namespace Battleship.Tests.Ships
{
    public class ShipTests
    {
        [Fact]
        public void ShouldBeAbleToChangeOrientation()
        {
            var ship = new DestroyerClassVessel();

            Assert.Equal(1, ship.Size.Width);
            Assert.Equal(3, ship.Size.Height);

            ship.FlipOrientation();

            Assert.Equal(3, ship.Size.Width);
            Assert.Equal(1, ship.Size.Height);
        }
    }
}