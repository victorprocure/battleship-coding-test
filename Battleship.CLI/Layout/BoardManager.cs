using System;
using System.Collections.Generic;
using System.Drawing;
using Battleship.CLI.Actors;

namespace Battleship.CLI.Layout
{
    public class BoardManager : IBoardManager
    {
        public IBoard this[IPlayer player] => boards[player];
        public Func<IBoard> BoardFactory { get; }

        private IDictionary<IPlayer, IBoard> boards;

        public BoardManager(Func<IBoard> boardFactory)
        {
            this.BoardFactory = boardFactory;
            this.boards = new Dictionary<IPlayer, IBoard>();
        }

        public void CreateBoard(IPlayer player)
        {
            this.boards.Add(player, this.BoardFactory());
        }
    }
}