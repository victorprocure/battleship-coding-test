using System.Collections.Generic;

namespace Battleship.CLI.Engine
{
    public interface ISuccessor
    {
        bool HasNext { get; }
        bool Complete { get; }
        IRound Next();
    }
}