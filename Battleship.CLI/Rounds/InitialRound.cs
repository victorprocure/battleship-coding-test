using System;
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
        private IResponseManager responseManager;

        public void Initialize(IPlayerManager playerManager, IResponseManager responseManager)
        {
            this.responseManager = responseManager;
            this.playerManager = playerManager;
            responseManager.SendMessage("Welcome to Battleship");

            this.Tick();
        }

        public void Tick()
        {
            this.responseManager.PoseQuestion("How Many Players? (2): ", this.AddPlayers);
        }

        public IRound Next()
        {
            return new ShipPlacementRound();
        }

        private void AddPlayers(string num)
        {
            var numPlayers = 2;
            if (!string.IsNullOrWhiteSpace(num))
            {
                numPlayers = Convert.ToInt32(num);
            }

            for (int i = 0; i < numPlayers; i++)
            {
                this.responseManager.PoseQuestion($"Player {i + 1} please enter your name: (Player {i + 1})", this.CreatePlayer);
            }

            this.complete = true;
        }

        private void CreatePlayer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                this.playerManager.AddPlayer();
            }
            else
            {
                this.playerManager.AddPlayer(name);
            }
        }
    }
}