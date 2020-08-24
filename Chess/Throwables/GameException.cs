using System;

namespace Chess.Throwables
{
    public class GameException : Exception
    {
        public GameException(string message) : base(message)
        {
        }
    }
}