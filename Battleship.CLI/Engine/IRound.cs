using System.Collections.Generic;

namespace Battleship.CLI.Engine
{
    public interface IRound : ISuccessor
    {
        int RequiredPlayers { get; }

        void Initialize(IList<Player> players);
    }
}