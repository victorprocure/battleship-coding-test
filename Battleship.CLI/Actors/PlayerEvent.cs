using System;
using Battleship.CLI.Actors;

namespace Battleship.CLI.Actors
{
    public class PlayerEvent
    {
        public string Message => message;

        public IPlayerAction Action => action;

        public Type ReturnType => returnType;

        public object ReturnValue => returnValue;

        private readonly IPlayerAction action;
        private readonly Type returnType;
        private readonly Object returnValue;

        private readonly string message;

        public PlayerEvent(IPlayerAction action, Type returnType, Object returnValue, string message) : this(action, returnType, returnValue)
        {
            this.message = message;
        }

        public PlayerEvent(IPlayerAction action, Type returnType, Object returnValue)
        {
            this.returnValue = returnValue;
            this.returnType = returnType;
            this.action = action;
        }
    }
}