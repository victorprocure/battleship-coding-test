using System.Collections.Generic;
using System.Drawing;
using Battleship.CLI.Actors;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;
using Moq;
using Xunit;

namespace Battleship.Tests.Actors
{
    public class PlayerTests
    {
        [Fact]
        public void ShouldBeAbleToPlacePieceOnBoard()
        {
            var coordinate = "A3";

            var mockBoard = new Mock<IBoard>();
            mockBoard.Setup(b=>b.AddShip(It.IsAny<string>(), It.IsAny<IBattleship>()));

            var mockBoardManager = new Mock<IBoardManager>();
            mockBoardManager.SetupGet(b=>b[It.IsAny<IPlayer>()]).Returns(mockBoard.Object);

            var mockShip = new Mock<IBattleship>();
            var player = new Player("Player", mockBoardManager.Object);

            player.CreateBattleship(coordinate, mockShip.Object);

            mockBoard.Verify(b =>
                b.AddShip(It.IsAny<string>(), It.IsAny<IBattleship>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GivenPlayerExecutedActionShouldRememberHistory()
        {
            var board1 = new Mock<IBoardManager>();
            var action = new Mock<IPlayerAction>();
            var retVal = new PlayerEvent(action.Object, typeof(string), "Works");
            action.Setup(a=>a.Execute(It.IsAny<IPlayer>())).Returns(retVal);
            var player1 = new Player("Test1", board1.Object);

            player1.Execute(action.Object);

            Assert.Contains(retVal, player1.Events);            
        }
    }
}