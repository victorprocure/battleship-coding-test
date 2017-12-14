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
            var coordinate = "A3";
            Player tPlayer = null;

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b=>b.AddShip(It.IsAny<string>(), It.IsAny<IBattleship>()));

            var mockShip = new Mock<IBattleship>();
            mockShip.SetupSet(s => s.Owner = It.IsAny<Player>()).Callback<Player>(p =>tPlayer = p);
            var player = new Player("Player", mockBoard.Object);

            player.CreateBattleship(coordinate, mockShip.Object);

            mockBoard.Verify(b =>
                b.AddShip(It.IsAny<string>(), It.IsAny<IBattleship>()), Times.AtLeastOnce());
            Assert.Equal(player, tPlayer);
        }

    }
}