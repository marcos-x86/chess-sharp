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
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row + 1, Position.Column);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;


            pos.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            Castling(mat);

            return mat;
        }

        public void Castling(bool[,] mat)
        {
            if (Movements == 0 && !_game.Status.Equals(GameStatus.Check))
            {
                var posR1 = new Position(Position.Row, Position.Column + 3);
                if (CastlingTest(posR1))
                {
                    var p1 = new Position(Position.Row, Position.Column + 1);
                    var p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null)
                        mat[Position.Row, Position.Column + 2] = true;
                }

                var posR2 = new Position(Position.Row, Position.Column - 4);
                if (CastlingTest(posR2))
                {
                    var p1 = new Position(Position.Row, Position.Column - 1);
                    var p2 = new Position(Position.Row, Position.Column - 2);
                    var p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null && Board.GetPiece(p3) == null)
                        mat[Position.Row, Position.Column - 2] = true;
                }
            }
        }

        public override string ToString()
        {
            return "K";
        }

        public void CheckKing()
        {
            throw new System.NotImplementedException();
        }

        private bool CanMove(Position pos)
        {
            var p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }

        private bool CastlingTest(Position pos)
        {
            var p = Board.GetPiece(pos);
            return p != null && p is Rook && p.Color == Color && p.Movements == 0;
        }
    }
}