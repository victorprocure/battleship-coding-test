namespace Battleship.CLI.Actors
{
    public interface IPlayerAction
    {
         PlayerEvent Execute(IPlayer player);
    }
}