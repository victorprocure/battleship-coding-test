using System;

namespace Battleship.CLI.Exceptions
{
    public class RequiredPlayersMissingException: Exception
    {
        public RequiredPlayersMissingException(): base("Not enough players") {}
    }
}