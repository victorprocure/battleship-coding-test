using System.Drawing;
using Battleship.CLI.Engine;

namespace Battleship.CLI.Ships
{
    public interface IBattleship
    {
        Orientation Orientation { get; }

        string Name { get; }

        Player Owner { get; set; }

        Rectangle Shape { get; set; }
    }
}