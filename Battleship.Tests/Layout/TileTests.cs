using System.Drawing;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;
using Moq;
using Xunit;

namespace Battleship.Tests.Layout
{
    public class TileTests
    {
        [Fact]
        public void GivenATileHasAShipItShouldMarkAsHitWhenFiredUpon()
        {
            var tile = new Tile();
            var mockShip = new Mock<IBattleship>();

            tile.AddShip(mockShip.Object);
            tile.FireAt();

            Assert.Equal(TileStatus.Hit, tile.Status);
        }

        [Fact]
        public void GivenATileHasNoShipItShouldMarkAsMissWhenFiredUpon()
        {
            var tile = new Tile();
            var mockShip = new Mock<IBattleship>();

            tile.FireAt();

            Assert.Equal(TileStatus.Missed, tile.Status);
        }

        [Fact]
        public void GivenTileIsHitShouldDamageShip()
        {
            var tile = new Tile();
            var mockShip = new Moq.Mock<Ship>(new object[]{ "Boat", new Size(1,3)});

            tile.AddShip(mockShip.Object);
            tile.FireAt();

            Assert.True(mockShip.Object.TakenDamage);
        }
    }
}