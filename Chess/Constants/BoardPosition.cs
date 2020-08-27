using System;

namespace Chess.Constants
{
    public enum BoardPosition
    {
        Upper,
        Lower
    }

    internal static class BoardPositionMethods
    {
        public static int GetPawnRow(this BoardPosition position)
        {
            return position switch
            {
                BoardPosition.Lower => 2,
                BoardPosition.Upper => 7,
                _ => 7
            };
        }

        public static int GetInitialPiecesRow(this BoardPosition position)
        {
            return position switch
            {
                BoardPosition.Lower => 1,
                BoardPosition.Upper => 8,
                _ => 8
            };
        }
    }
}