namespace Chess.Pieces
{
    internal class Horse : Piece
    {
        public Horse(Board brd, Color color) : base(color, brd)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            var mat = new bool[Board.Rows, Board.Columns];
            var pos = new Position(0, 0);

            pos.SetValues(Position.Row - 1, Position.Column - 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            pos.SetValues(Position.Row - 2, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            pos.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            pos.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            pos.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            pos.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            pos.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.IsValidPosition(pos) && CanMove(pos))
                mat[pos.Row, pos.Column] = true;
            pos.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.IsValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;
            return mat;
        }
        
        private bool CanMove(Position pos)
        {
            var p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }
        
        public override string ToString()
        {
            return "H";
        }
    }
}