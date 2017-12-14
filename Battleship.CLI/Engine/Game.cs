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
        public IRound Round { get; private set; }

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
        }

        public void Tick()
        {
            if (this.Round.Complete && this.Round.HasNext)
            {
                this.Round = this.Round.Next();
                this.BeginRound();
            }
            else
            {
                this.Round.Tick();
            }


            var defeat = this.playerManager.CheckDefeats();
            if (defeat != null)
            {
                this.Complete = true;

                this.responseManager.SendMessage($"{defeat.Name}: you sunk my battleship");
            }
            else
            {
                this.Complete = false;

            }
        }

        private void BeginRound()
        {
            if (this.playerManager.Count < this.Round.RequiredPlayers)
            {
                throw new RequiredPlayersMissingException();
            }

            this.Round.Initialize(this.playerManager, this.responseManager);
        }
    }
}