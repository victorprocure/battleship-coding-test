using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battleship.CLI.Layout;

namespace Battleship.CLI.Actors
{
    public class PlayerManager : IPlayerManager
    {
        public IPlayer this[int index] => players[index];

        public IPlayer this[string name] => players.Single(p => p.Name.Equals(name));

        public IPlayer this[IPlayer player] => players.Single(p => p == player);

        public int Count => players.Count;

        private IList<IPlayer> players;

        private readonly IBoardManager boardManager;

        public PlayerManager(IBoardManager boardManager)
        {
            this.boardManager = boardManager;
            this.players = new List<IPlayer>();
        }

        public void AddPlayer()
        {
            var nextNumber = this.players.Count + 1;
            var defaultName = $"Player {nextNumber}";

            this.AddPlayer(defaultName);
        }

        public void AddPlayer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.players.Add(new Player(name, this.boardManager));
        }

        public IEnumerator<IPlayer> GetEnumerator()
        {
            return this.players.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}