using System.Collections.Generic;
using Battleship.CLI.Ships;

namespace Battleship.CLI.Layout
{
    public interface IBoard
    {
        IList<IBattleship> Ships { get; }

        IList<string> ColumnHeaders { get; }
        IList<string> RowHeaders { get; }

        int HorizontalTiles { get; }
        int VerticalTiles { get; }

        void AddShip(IBattleship ship);
        
        void Initialize();

        Tile GetTile(string coordinates);
    }
}