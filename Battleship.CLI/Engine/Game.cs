using System;
using System.Collections.Generic;
using System.Drawing;
using Battleship.CLI.Actors;
using Battleship.CLI.Exceptions;
using Battleship.CLI.Layout;

namespace Battleship.CLI.Engine
{
    public class Game
    {
        public IRound Round { get; }
        
        public bool Complete { get; private set; }

        private IPlayerManager playerManager;
        private IResponseManager responseManager;


        public Game(IPlayerManager playerManager, IRound round, IResponseManager responseManager)
        {
            this.Round = round;
            this.playerManager = playerManager;
            this.responseManager = responseManager;
        }

        public void Begin()
        {
            this.BeginRound();

            while (this.Round.HasNext && !this.Round.Complete)
            {
                this.Complete = false;
            }

            this.Complete = true;
        }

        private void BeginRound()
        {
            if (this.playerManager.Count < this.Round.RequiredPlayers)
            {
                throw new RequiredPlayersMissingException();
            }

            if (this.Round.RequiredPlayers != 0)
            {
                this.Round.Initialize(this.playerManager);
            }
        }
    }
}