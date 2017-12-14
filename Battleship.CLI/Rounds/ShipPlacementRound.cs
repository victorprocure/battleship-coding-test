using Battleship.CLI.Actors;
using Battleship.CLI.Engine;
using Battleship.CLI.Layout;
using Battleship.CLI.Ships;
using Battleship.CLI.UI;

namespace Battleship.CLI.Rounds
{
    public class ShipPlacementRound : IRound
    {
        public int RequiredPlayers => 2;

        public bool HasNext => true;

        public bool Complete => complete;

        private bool complete = false;
        private IPlayerManager playerManager;
        private IResponseManager responseManager;
        private BoardRenderer boardRenderer;

        public void Initialize(IPlayerManager playerManager, IResponseManager responseManager)
        {
            this.responseManager = responseManager;
            this.playerManager = playerManager;
            this.boardRenderer = new BoardRenderer();
        }

        public IRound Next()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {

            foreach (var player in this.playerManager)
            {
                this.Redraw(playerManager[player].Board);
                this.AskToPlace(player);
                this.AskToOrient(player);
                this.Verify(player);
            }
        }

        private void AskToPlace(IPlayer player) {
                this.responseManager.PoseQuestion($"{player.Name} please place your ship (format: A1): ", (s) => this.PlaceShip(s, player));
        }

        private void Verify(IPlayer player) {
            this.Redraw(playerManager[player].Board);
            this.responseManager.PoseQuestion($"Is this correct (y/n): ", this.Verify);
        }

        private void AskToOrient(IPlayer player) {
            this.responseManager.PoseQuestion($"{player.Name} would you like to rotate boat?: (y/n)", (s) => this.RotateShip(s, player));
        }

        private void Redraw(IBoard board)
        {
            this.responseManager.ClearScreen();
                this.responseManager.SendMessage(this.boardRenderer.DrawBoard(board));
        }

        private void PlaceShip(string coordinates, IPlayer player)
        {
            player.Board.MoveShip(coordinates, new DestroyerClassVessel());
        }

        private void RotateShip(string confirm, IPlayer player) {
            if(confirm.Contains("Y") || confirm.Contains("y")) {
                var b = new DestroyerClassVessel();
                b.FlipOrientation();
                player.Board.MoveShip("A1", b );
            } else {
                this.PlaceShip("A1", player);
            }
        }

        private void Verify(string confirmation) {

        }
    }
}