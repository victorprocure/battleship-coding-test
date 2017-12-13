using System.Drawing;

namespace Battleship.CLI.Layout
{
    public class Tile
    {
        public Point Location { get; }

        public Tile(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}