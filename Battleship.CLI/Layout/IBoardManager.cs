using System.Drawing;
using Battleship.CLI.Actors;
using System;

namespace Battleship.CLI.Layout
{
    public interface IBoardManager
    {
        IBoard this[IPlayer player] { get; }
        Func<IBoard> BoardFactory { get; }

        void CreateBoard(IPlayer player);
    }
}