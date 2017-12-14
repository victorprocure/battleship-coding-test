using Xunit;
using Moq;
using Battleship.CLI.Engine;
using Battleship.CLI.Exceptions;
using System.Linq;
using System;
using Battleship.CLI.Layout;
using Battleship.CLI.Actors;

namespace Battleship.Tests.Engine
{
    public class GameTests
    {
        [Fact]
        public void ShouldCompleteWhenNoMoreRoundsAndRoundComplete()
        {
            var mockResponseManager = new Mock<ResponseManager>();
            var mockRound = new Mock<IRound>();
            mockRound.SetupGet(r => r.HasNext).Returns(false);
            mockRound.SetupGet(r => r.Complete).Returns(true);
            var playerManager = new Mock<IPlayerManager>();


            var game = new Game(playerManager.Object, mockRound.Object, mockResponseManager.Object);
            game.Begin();

            Assert.True(game.Complete);
        }

        [Fact]
        public void ShouldVerifyNumberOfPlayersRequiredForRound()
        {
            var mockResponseManager = new Mock<ResponseManager>();
            var mockRound = new Mock<IRound>();
            mockRound.SetupGet(r => r.RequiredPlayers).Returns(2);
            var playerManager = new Mock<IPlayerManager>();


            var game = new Game(playerManager.Object, mockRound.Object, mockResponseManager.Object);

            Assert.Throws<RequiredPlayersMissingException>(() => game.Begin());
        }

        private Game GetDefaultGame()
        {
            var mockRound = new Mock<IRound>();
            var mockResponseManager = new Mock<ResponseManager>();
            var playerManager = new Mock<IPlayerManager>();
            var game = new Game(playerManager.Object, mockRound.Object, mockResponseManager.Object);
            return game;
        }
    }
}