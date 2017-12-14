using System;

namespace Battleship.CLI.Engine
{
    public class ResponseManager : IResponseManager
    {
        public void PoseQuestion(string message, Action<string> callback)
        {
            Console.WriteLine(message);
            var read = Console.ReadLine();

            callback(read);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}