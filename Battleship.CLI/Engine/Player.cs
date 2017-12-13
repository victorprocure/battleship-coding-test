using System.Drawing;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;

namespace Battleship.CLI.Engine
{
    public class Player
    {
        public string Name { get; }
        public Board Board { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public void AddBattleship(Point location, IBattleship ship, IBoard board)
        {
            ship.Shape = new Rectangle(location, ship.Shape.Size);
            ship.Owner = this;

            board.AddShip(ship);
        }
    }
}