using System.Collections.Generic;
using Battleship.CLI.Ships;
using System.Drawing;

namespace Battleship.CLI.Layout
{
    public interface IBoard
    {
        IList<IBattleship> Ships { get; }

        Size Size { get; }

        int HorizontalTiles { get; }
        int VerticalTiles { get; }

        int TileWidth { get; }
        int TileHeight { get; }

        void AddShip(IBattleship ship);
        void Initialize();

        string DrawBoard();
    }
}