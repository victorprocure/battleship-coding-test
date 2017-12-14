using System;
using System.Collections.Generic;
using System.Drawing;
using Battleship.CLI.Exceptions;
using Battleship.CLI.Layout;

namespace Battleship.CLI.Engine
{
    public class Game
    {
        public IRound Round { get; }

        public IList<Player> Players { get; }

        public bool Complete { get; private set; }

        private Point boardSize;

        public Game(IRound round) : this(round, new Point(9, 9))
        {
            this.Round = round;
            this.Players = new List<Player>();
        }

        public Game(IRound round, Point boardSize)
        {
            this.boardSize = boardSize;
        }

        public Game(IRound round, int boardSize): this(round, new Point(boardSize,boardSize)) { }

        public void Begin()
        {
            this.BeginRound();

            while (this.Round.HasNext && !this.Round.Complete)
            {
                this.Complete = false;
            }

            this.Complete = true;
        }

        public void AddPlayer()
        {
            var nextNumber = this.Players.Count + 1;
            var defaultName = $"Player {nextNumber}";

            this.AddPlayer(defaultName);
        }

        public void AddPlayer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Players.Add(new Player(name, new Board(this.boardSize.Y, this.boardSize.X)));
        }

        private void BeginRound()
        {
            if (this.Players.Count < this.Round.RequiredPlayers)
            {
                throw new RequiredPlayersMissingException();
            }

            if (this.Round.RequiredPlayers != 0)
            {
                this.Round.Initialize(this.Players);
            }
        }
    }
}