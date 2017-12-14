using System;
using System.Collections.Generic;
using System.Drawing;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;

namespace Battleship.CLI.Actors
{
    public class Player: IPlayer
    {
        public string Name { get; }

        public IBoard Board => boardManager[this];

        public IList<PlayerEvent> Events {get;}

        private IBoardManager boardManager;

        public Player(string name, IBoardManager boardManager)
        {
            this.Name = name;

            boardManager.CreateBoard(this);
            this.boardManager = boardManager;
            
            this.Events = new List<PlayerEvent>();
        }

        public void CreateBattleship(string coordinates, IBattleship ship)
        {
            this.Board.AddShip(coordinates, ship);
        }


        public PlayerEvent Execute(IPlayerAction action)
        {
            var ret = action.Execute(this);
            this.Events.Add(ret);

            return ret;
        }
    }
}