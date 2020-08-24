using System;

namespace Chess.Throwables
{
    public class ChessException : Exception
    {
        public ChessException(string message) : base(message)
        {
        }
    }
}