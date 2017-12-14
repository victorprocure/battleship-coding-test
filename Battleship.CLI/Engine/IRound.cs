using System.Collections.Generic;
using Battleship.CLI.Actors;

namespace Battleship.CLI.Engine
{
    public interface IRound : ISuccessor
    {
        int RequiredPlayers { get; }

        void Initialize(IPlayerManager playerManager);
    }
}