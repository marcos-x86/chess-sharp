using Chess.Pieces;

namespace Chess
{
    public class Board
    {
        private const int Dimension = 8;
        private readonly Piece[,] _pieces;
        public int Rows { get; }
        public int Columns { get; }

        public Board()
        {
            Rows = Dimension;
            Columns = Dimension;
            _pieces = new Piece[Dimension, Dimension];
        }

        public Piece GetPiece(Position pos)
        {
            return _pieces[pos.Row, pos.Column];
        }

        public void SetPiece(Piece piece, Position position)
        {
            piece.Position = position;
            _pieces[position.Row, position.Column] = piece;
        }
        
        public Piece RemovePiece(Position pos)
        {
            var aux = GetPiece(pos);
            if (aux == null)
                return null;
            aux.Position = null;
            _pieces[pos.Row, pos.Column] = null;
            return aux;
        }

        public bool IsValidPosition(Position pos)
        {
            return pos.Row >= 0 && pos.Row < Rows && pos.Column >= 0 && pos.Column < Columns;
        }
    }
}