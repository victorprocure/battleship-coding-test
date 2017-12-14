using System;
using System.Linq;
using Battleship.CLI.Actors;
using Battleship.CLI.Layout;
using Moq;
using Xunit;

namespace Battleship.Tests.Actors
{
    public class PlayerManagerTests
    {
        [Fact]
        public void ShouldCreateDefaultNumberedNameForPlayerWhenNoneGiven()
        {
            var mockBoard = new Mock<IBoardManager>();
            
            var playerManager = new PlayerManager(mockBoard.Object);

            playerManager.AddPlayer();

            Assert.Contains(playerManager.Count().ToString(), playerManager.First().Name);
        }

        [Fact]
        public void ShouldThrowIfAttemptingToAddBlankName()
        {
            var mockBoard = new Mock<IBoardManager>();
            var playerManager = new PlayerManager(mockBoard.Object);

            Assert.Throws<ArgumentNullException>(() => playerManager.AddPlayer("   "));
        }

        [Fact]
        public void GivenAPlayerAddedShouldHaveTheirOwnBoard()
        {
            var mockBoardManager = new Mock<IBoardManager>();
            mockBoardManager.SetupGet(b=>b[It.IsAny<IPlayer>()]).Returns(new Board(9));
            var playerManager = new PlayerManager(mockBoardManager.Object);

            playerManager.AddPlayer("Test Player");
            var player = playerManager.First();

            var headerPadding = 1;
            Assert.Equal(9 - headerPadding, player.Board.Size.X);
        }
    }
}