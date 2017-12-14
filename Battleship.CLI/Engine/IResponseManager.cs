namespace Battleship.CLI.Engine
{
    public interface IResponseManager
    {
         void PoseQuestion(string message);
         
         string Respond();
    }
}