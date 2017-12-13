namespace Battleship.CLI.Engine
{
    public interface IRound
    {
        bool HasNext { get; }
        bool Complete { get; }
        int RequiredPlayers { get; }

        IRound Next();
    }
}