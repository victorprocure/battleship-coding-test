using System.Drawing;
using Battleship.CLI.Engine;

namespace Battleship.CLI.Ships
{
    public interface IBattleship
    {
        string Name { get; }

        Player Owner { get; set; }

        Size Size { get; set; }
    }
}