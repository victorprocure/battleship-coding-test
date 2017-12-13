using System.Collections.Generic;
using System.Drawing;
using Battleship.CLI.Engine;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;
using Moq;
using Xunit;

namespace Battleship.Tests.Engine
{
    public class PlayerTests
    {
        [Fact]
        public void ShouldBeAbleToPlacePieceOnBoard()
        {
            var mockBoard = new Mock<IBoard>();
            var ships = new List<IBattleship>();
            mockBoard.SetupGet(b=>b.Ships).Returns(ships);
            mockBoard.Setup(s => s.AddShip(It.IsAny<IBattleship>())).Callback<IBattleship>((s) => ships.Add(s));
            var mockShip = new Mock<IBattleship>();

            Player p = new Player("test");
            Rectangle r = new Rectangle();
            mockShip.SetupSet(s => s.Owner = It.IsAny<Player>()).Callback<Player>(e => p = e);
            mockShip.SetupSet(s => s.Shape = It.IsAny<Rectangle>()).Callback<Rectangle>(e => r = e);
            var player = new Player("Player");

            var location = new Point(2, 3);
            player.AddBattleship(location, mockShip.Object, mockBoard.Object);

            Assert.Equal(p, player);
            Assert.Equal(r.Location, location);
            Assert.Contains(mockShip.Object, mockBoard.Object.Ships);
        }
    }
}