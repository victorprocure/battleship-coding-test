using System.Drawing;

namespace Battleship.CLI.Ships
{
    public abstract class Ship : IBattleship
    {
        public string Name { get; }
        public Size Size => size;
        public int Hitpoints => 3;

        public bool Destroyed => Hitpoints - hits <= 0;

        public bool TakenDamage => hits > 0;

        private Size size;

        private int hits = 0;

        public Ship(string name, Size size)
        {
            this.Name = name;
            this.size = size;
        }

        public void FlipOrientation()
        {
            this.size = new Size(this.size.Height, this.size.Width);
        }

        public void DamageTaken(int amount) {
            this.hits += amount;
        }
    }
}