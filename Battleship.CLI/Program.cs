using System;
using Battleship.CLI.Actors;
using Battleship.CLI.Engine;
using Battleship.CLI.Layout;
using Battleship.CLI.Rounds;

namespace Battleship.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardManager = new BoardManager(() => new Board(9));
            var playerManager = new PlayerManager(boardManager);
            var initialRound = new InitialRound();
            var responseManager = new ResponseManager();

            var game = new Game(playerManager, initialRound, responseManager);

            var hardClose = false;
            game.Begin();
            while (!game.Complete && !hardClose)
            {
                game.Tick();
                
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            hardClose = true;
                            break;
                    }
                }
            }

            Console.WriteLine("Exiting...");
        }
    }
}
