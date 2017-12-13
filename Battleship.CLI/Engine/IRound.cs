using System.Collections.Generic;

namespace Battleship.CLI.Engine
{
    public interface IRound
    {
        bool HasNext { get; }
        bool Complete { get; }
        int RequiredPlayers { get; }

        void Initialize(IList<Player> players);

        IRound Next();
    }
}