using System.Drawing;
using System.Linq;
using Battleship.CLI.Layout;
using Xunit;

namespace Battleship.Tests.Layout
{
    public class BoardTests
    {
        [Fact]
        public void GivenTileNumberShouldCreateColumnHeaders()
        {
            var board = new Board(9);

            board.Initialize();

            Assert.Equal(9, board.ColumnHeaders.Count());
        }

        [Fact]
        public void GivenTileNumberShouldCreateRowHeaders()
        {
            var board = new Board(9);

            board.Initialize();

            Assert.Equal(9, board.RowHeaders.Count());
        }

        [Fact]
        public void ColumnHeaderShouldHaveBlankAsFirst()
        {
            var board = new Board(9);

            board.Initialize();

            Assert.Equal(string.Empty, board.ColumnHeaders.First());
        }

        [Fact]
        public void RowHeadersShouldHaveBlankAsFirst()
        {
            var board = new Board(9);

            board.Initialize();

            Assert.Equal(string.Empty, board.RowHeaders.First());
        }

        [Fact]
        public void TileShouldBeAccessibleByCoordinate()
        {
            var board = new Board(9);

            board.Initialize();
            var tile = board.GetTile("A2");

            Assert.Equal(new Point(0, 1), tile.Location);

        }

        [Fact]
        public void GivenAShipBeingPlacedShouldNotConflictWithAnotherAlreadyPlaced()
        {
            Assert.True(false);
        }

        [Fact]
        public void GivenOnePlayerShouldNotSeeAnotherPlayersShips()
        {
            Assert.True(false);
        }
    }
}