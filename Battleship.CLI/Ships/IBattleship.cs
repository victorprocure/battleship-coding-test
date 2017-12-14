using System.Drawing;
using Battleship.CLI.Actors;
using Battleship.CLI.Engine;

namespace Battleship.CLI.Ships
{
    public interface IBattleship
    {
        string Name { get; }

        Size Size { get; }

        void FlipOrientation();
    }
}