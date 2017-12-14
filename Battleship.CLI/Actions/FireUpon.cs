using System;
using System.Linq.Expressions;
using Battleship.CLI.Actors;
using Battleship.CLI.Layout;

namespace Battleship.CLI.Actions
{
    public class FireUpon : IPlayerAction
    {
        private IPlayer opponent;
        private string coordinates;

        private FireUpon(IPlayer opponent, string coordinates) {
            this.opponent = opponent;
            this.coordinates = coordinates;
         }

        public static FireUpon Target(IPlayer opponent, string coordinates)
        {
            var fireUpon = new FireUpon(opponent, coordinates);
            return fireUpon;
        }

        public PlayerEvent Execute(IPlayer player)
        {
            var tile = opponent.Board.GetTile(coordinates);
            tile.FireAt();

            return new PlayerEvent(this, typeof(TileStatus), tile.Status);
        }
    }
}