using System;
using System.Drawing;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;

namespace Battleship.CLI.Engine
{
    public class Player
    {
        public string Name { get; }

        public IBoard Board { get; }

        public Player(string name, IBoard board)
        {
            this.Name = name;
            this.Board = board;
        }

        public void CreateBattleship(string coordinates, IBattleship ship)
        {
            ship.Owner = this;
            this.Board.AddShip(coordinates, ship);
        }
    }
}