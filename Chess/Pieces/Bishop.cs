namespace Chess.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(color, board)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            var board = new bool[Board.Rows, Board.Columns];
            var position = new Position(0, 0);

            position.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                board[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color) break;
                position.SetValues(position.Row - 1, position.Column + 1);
            }

            position.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                board[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color) break;
                position.SetValues(position.Row - 1, position.Column - 1);
            }

            position.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                board[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color) break;
                position.SetValues(position.Row + 1, position.Column + 1);
            }

            position.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                board[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color) break;
                position.SetValues(position.Row + 1, position.Column - 1);
            }

            return board;
        }
        
        public override string ToString()
        {
            return "B";
        }
        
        private bool CanMove(Position pos)
        {
            var p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }
    }
}