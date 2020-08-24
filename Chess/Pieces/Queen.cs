namespace Chess.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Board brd, Color color) : base(color, brd)
        {
        }


        public override string ToString()
        {
            return "Q";
        }

        private bool CanMove(Position pos)
        {
            var p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] GetAvailablePositions()
        {
            var mat = new bool[Board.Rows, Board.Columns];
            var pos = new Position(0, 0);


            pos.SetValues(Position.Row - 1, Position.Column);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row - 1, pos.Column);
            }


            pos.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row - 1, pos.Column + 1);
            }


            pos.SetValues(Position.Row, Position.Column + 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row, pos.Column + 1);
            }


            pos.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row + 1, pos.Column + 1);
            }


            pos.SetValues(Position.Row + 1, Position.Column);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row + 1, pos.Column);
            }


            pos.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row + 1, pos.Column - 1);
            }


            pos.SetValues(Position.Row, Position.Column - 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row, pos.Column - 1);
            }


            pos.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.IsValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color) break;
                pos.SetValues(pos.Row - 1, pos.Column - 1);
            }

            return mat;
        }
    }
}