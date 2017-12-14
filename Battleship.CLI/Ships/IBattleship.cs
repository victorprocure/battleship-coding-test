using System.Drawing;
using Battleship.CLI.Actors;
using Battleship.CLI.Engine;

namespace Battleship.CLI.Ships
{
    public interface IBattleship
    {
        string Name { get; }

        int Hitpoints { get; }

        Size Size { get; }

        bool Destroyed {get;}

        void FlipOrientation();

        void DamageTaken(int amount);
    }
}