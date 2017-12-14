using System;

namespace Battleship.CLI.Engine
{
    public interface IResponseManager
    {
         void PoseQuestion(string message, Action<string> callback);
         
         void SendMessage(string message);

         void ClearScreen();
    }
}