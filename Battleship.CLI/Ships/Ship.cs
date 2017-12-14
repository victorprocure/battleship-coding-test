using System.Drawing;

namespace Battleship.CLI.Ships
{
    public abstract class Ship : IBattleship
    {
        public string Name { get; }
        public Size Size => size;

        private Size size;

        public Ship(string name, Size size)
        {
            this.Name = name;
            this.size = size;
        }

        public void FlipOrientation()
        {
            this.size = new Size(this.size.Height, this.size.Width);
        }
    }
}