namespace Chess.Pieces
{
    internal class King : Piece, ICastling
    {
        private readonly ChessGame _game;

        public King(Board brd, Color color, ChessGame game) : base(color, brd)
        {
            this._game = game;
        }

        public override bool[,] GetAvailablePositions()
        {
            var mat = new bool[Board.Rows, Board.Columns];
            var pos = new Position(0, 0);


            pos.SetValues(Position.Row - 1, Position.Column);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row + 1, Position.Column);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            EvaluateCastling(mat);
            return mat;
        }

        public void EvaluateCastling(bool[,] mat)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            var p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }

        private bool CastlingTest(Position pos)
        {
            var piece = Board.GetPiece(pos);
            return piece is Rook && piece.Color == Color && piece.Movements == 0;
        }
    }
}