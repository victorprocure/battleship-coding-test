using System;
using System.Collections.Generic;
using Battleship.CLI.Exceptions;
using Battleship.CLI.Layout;

namespace Battleship.CLI.Engine
{
    public class Game
    {
        public IRound Round { get; }

        public IList<Player> Players { get; }

        public IBoard Board { get; }

        public bool Complete { get; private set; }

        public Game(IRound round, IBoard board)
        {
            this.Round = round;
            this.Players = new List<Player>();
            this.Board = board;
        }

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

            this.Players.Add(new Player(name));
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