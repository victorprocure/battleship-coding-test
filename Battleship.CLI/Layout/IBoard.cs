using System.Collections.Generic;
using System.Drawing;
using Battleship.CLI.Ships;

namespace Battleship.CLI.Layout
{
    public interface IBoard
    {
        IList<string> ColumnHeaders { get; }
        IList<string> RowHeaders { get; }
        TileCollection TileCollection {get;}
        Point Size { get; }

        void AddShip(string coordinates, IBattleship ship);

        void MoveShip(string coordinates, IBattleship ship);

        Tile GetTile(string coordinates);
    }
}