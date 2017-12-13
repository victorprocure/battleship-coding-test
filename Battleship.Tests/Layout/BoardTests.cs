using System.Drawing;
using Battleship.CLI.Layout;
using Xunit;

namespace Battleship.Tests.Layout
{
    public class BoardTests
    {
        [Fact]
        public void GivenEasyNumbersShouldCreateEqualGrid()
        {
            var board = new Board(90, 90, 9);

            board.Initialize();

            Assert.Equal(10, board.TileHeight);
            Assert.Equal(10, board.TileWidth);
        }

        [Fact]
        public void GivenSillyNumbersShouldCreateEqualGrid()
        {
            var board = new Board(100, 100, 9);

            board.Initialize();

            Assert.Equal(11, board.TileHeight);
            Assert.Equal(11, board.TileWidth);
        }

        [Fact]
        public void GivenNumbersShouldDrawGrid()
        {
            var board = new Board(100, 100, 9);

            board.Initialize();

            var b = board.DrawBoard();

            Assert.NotNull(b);
        }

        [Fact]
        public void GivenAShipBeingPlacedShouldNotConflictWithAnotherAlreadyPlaced()
        {

        }

        [Fact]
        public void GivenOnePlayerShouldNotSeeAnotherPlayersShips()
        {
            
        }
    }
}