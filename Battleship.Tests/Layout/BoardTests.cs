using System;
using System.Drawing;
using System.Linq;
using Battleship.CLI.Engine;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;
using Moq;
using Xunit;

namespace Battleship.Tests.Layout
{
    public class BoardTests
    {
        [Fact]
        public void GivenTileNumberShouldCreateColumnHeaders()
        {
            var board = new Board(9);

            Assert.Equal(9, board.ColumnHeaders.Count());
        }

        [Fact]
        public void GivenTileNumberShouldCreateRowHeaders()
        {
            var board = new Board(9);

            Assert.Equal(9, board.RowHeaders.Count());
        }

        [Fact]
        public void ColumnHeaderShouldHaveBlankAsFirst()
        {
            var board = new Board(9);

            Assert.Equal(string.Empty, board.ColumnHeaders.First());
        }

        [Fact]
        public void RowHeadersShouldHaveBlankAsFirst()
        {
            var board = new Board(9);

            Assert.Equal(string.Empty, board.RowHeaders.First());
        }

        [Fact]
        public void ShouldAllowShipToBePlaced()
        {
            var board = new Board(9);
            var mockShip = new Mock<IBattleship>();
            mockShip.SetupGet(s => s.Size).Returns(new Size(1,3));

            board.AddShip("A1", mockShip.Object);

            Assert.NotNull(board.GetTile("A2").Ship);
        }

        [Fact]
        public void ShouldNotAllowShipToBePlacedOutOfBounds()
        {
            var board = new Board(9);
            var mockShip = new Mock<IBattleship>();
            mockShip.SetupGet(s => s.Size).Returns(new Size(1,3));

            board.AddShip("H8", mockShip.Object);

            Assert.NotNull(board.GetTile("H6").Ship);
        }

        
    }
}