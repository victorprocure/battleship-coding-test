using System.Collections.Generic;
using Battleship.CLI.Layout;

namespace Battleship.CLI.Actors
{
    public interface IPlayer
    {
         string Name {get;}
         
         IBoard Board {get;}

         IList<PlayerEvent> Events {get;}

         PlayerEvent Execute(IPlayerAction action);
    }
}