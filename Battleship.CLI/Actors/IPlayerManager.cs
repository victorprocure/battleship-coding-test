using System.Collections.Generic;
using Battleship.CLI.Layout;

namespace Battleship.CLI.Actors
{
    public interface IPlayerManager : IEnumerable<IPlayer>
    {
        IPlayer this[int index] { get; }
        IPlayer this[string name] { get; }
        IPlayer this[IPlayer player] { get; }
        int Count {get;}

        IPlayer CheckDefeats();

        void AddPlayer();

        void AddPlayer(string name);
    }
}