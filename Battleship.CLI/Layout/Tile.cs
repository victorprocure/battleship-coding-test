using System.Drawing;
using Battleship.CLI.Ships;

namespace Battleship.CLI.Layout
{
    public class Tile
    {
        public Point Location { get; }

        public IBattleship Ship { get; private set; }

        public TileStatus Status { get; private set; } = TileStatus.Untouched;

        public Tile(): this(0,0) { }
        
        public Tile(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        public void AddShip(IBattleship ship)
        {
            this.Ship = ship;
        }

        public void FireAt()
        {
            if(this.Ship != null)
            {
                this.Status = TileStatus.Hit;

                return;
            }

            this.Status = TileStatus.Missed;
        }
    }
}