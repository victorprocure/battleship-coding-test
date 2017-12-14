using System.Collections.Generic;
using Battleship.CLI.Actors;
using Battleship.CLI.Engine;

namespace Battleship.CLI.Rounds
{
    public class InitialRound : IRound
    {
        public int RequiredPlayers => 0;

        public bool HasNext => true;

        public bool Complete => complete;

        private bool complete = false;

        private IPlayerManager playerManager;

        public void Initialize(IPlayerManager playerManager)
        {
            this.playerManager = playerManager;

            this.Loop();
        }

        private void Loop()
        {
            while(!complete)
            {

            }
        }

        public IRound Next()
        {
            throw new System.NotImplementedException();
        }
    }
}