using Chess.Pieces;

namespace Chess
{
    public class Board
    {
        public const int Dimension = 8;
        private readonly Piece[,] _pieces;

        public Board()
        {
            _pieces = new Piece[Dimension, Dimension];
        }

        public Piece GetPiece(Position position)
        {
            return _pieces[position.Row, position.Column];
        }

        public void SetPiece(Piece piece, Position position)
        {
            piece.Position = position;
            _pieces[position.Row, position.Column] = piece;
        }

        public Piece UnsetPiece(Position position)
        {
            var piece = GetPiece(position);
            _pieces[position.Row, position.Column] = null;
            return piece;
        }
    }
}