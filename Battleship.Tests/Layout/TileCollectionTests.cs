using System;
using System.Drawing;
using Battleship.CLI.Layout;
using Xunit;

namespace Battleship.Tests.Layout
{
    public class TileCollectionTests
    {
        [Fact]
        public void TileShouldBeAccessibleByCoordinate()
        {
            var tiles = new TileCollection(9, 9);

            var tile = tiles[0,1];

            Assert.Equal(new Point(0, 1), tile.Location);

        }

        [Fact]
        public void GivenInvalidTileShouldThrowOutOfRangeException()
        {
            var tiles = new TileCollection(9, 9);


            Assert.Throws<IndexOutOfRangeException>(() => tiles[99,22]);
        }
        
    }
}