using Xunit;
using Moq;
using Battleship.CLI.Engine;
using Battleship.CLI.Exceptions;
using System.Linq;
using System;

namespace Battleship.Tests.Engine
{
    public class GameTests
    {
        [Fact]
        public void ShouldCompleteWhenNoMoreRoundsAndRoundComplete()
        {
            var mockRound = new Mock<IRound>();
            mockRound.SetupGet(r => r.HasNext).Returns(false);
            mockRound.SetupGet(r => r.Complete).Returns(true);

            var game = new Game(mockRound.Object);
            game.Begin();

            Assert.True(game.Complete);
        }

        [Fact]
        public void ShouldVerifyNumberOfPlayersRequiredForRound()
        {
            var mockRound = new Mock<IRound>();
            mockRound.SetupGet(r => r.RequiredPlayers).Returns(2);
            var game = new Game(mockRound.Object);

            Assert.Throws<RequiredPlayersMissingException>(() => game.Begin());
        }

        [Fact]
        public void ShouldCreateDefaultNumberedNameForPlayerWhenNoneGiven()
        {
            var game = this.GetDefaultGame();

            game.AddPlayer();

            Assert.Contains(game.Players.Count.ToString(), game.Players.First().Name);
        }

        [Fact]
        public void ShouldThrowIfAttemptingToAddBlankName()
        {
            var game = this.GetDefaultGame();

            Assert.Throws<ArgumentNullException>(() => game.AddPlayer("   "));
        }

        private Game GetDefaultGame()
        {
            var mockRound = new Mock<IRound>();
            var game = new Game(mockRound.Object);
            return game;
        }
    }
}