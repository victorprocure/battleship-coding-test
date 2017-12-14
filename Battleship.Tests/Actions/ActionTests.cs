using Battleship.CLI.Actions;
using Battleship.CLI.Actors;
using Battleship.CLI.Layout;
using Moq;
using Xunit;

namespace Battleship.Tests.Actions
{
    public class ActionTests
    {
        [Fact]
        public void ShouldBeAbleToFireUponAnotherPlayer()
        {
            var board1 = new Mock<IBoardManager>();
            var player1 = new Player("Test", board1.Object);

            var board2 = new Mock<IBoard>();
            board2.Setup(b=>b.GetTile(It.IsAny<string>())).Returns(new Tile(0,0));
            var player2 = new Mock<IPlayer>();
            player2.SetupGet(p=>p.Board).Returns(board2.Object);

            var fireUpon = FireUpon.Target(player2.Object, "A1");

            var status = player1.Execute(fireUpon);

            Assert.IsType<TileStatus>(status.ReturnValue);
        }

        
    }
}