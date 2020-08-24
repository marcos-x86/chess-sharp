using System;

namespace Chess.Throwables
{
    public class MoveException : Exception
    {
        public MoveException(string message) : base(message)
        {
        }
    }
}