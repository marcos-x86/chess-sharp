﻿namespace Chess.Pieces
{
    internal class Pawn : Piece, IPown

    {
        private ChessGame Match;

        public Pawn(Board brd, Color color, ChessGame match) : base(color, brd)
        {
            Match = match;
        }

        private bool IsThereEnemy(Position pos)
        {
            var p = Board.GetPiece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.GetPiece(pos) == null;
        }

        public override bool[,] GetAvailablePositions()
        {
            var mat = new bool[Board.Rows, Board.Columns];
            var pos = new Position(0, 0);

            if (Color == Match.Player1.Color)
            {
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.IsValidPosition(pos) && Free(pos)) mat[pos.Row, pos.Column] = true;

                pos.SetValues(Position.Row - 2, Position.Column);
                var p2 = new Position(Position.Row - 1, Position.Column);
                if (Board.IsValidPosition(p2) && Free(p2) && Board.IsValidPosition(pos) && Free(pos) &&
                    Movements == 0) mat[pos.Row, pos.Column] = true;

                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsValidPosition(pos) && IsThereEnemy(pos)) mat[pos.Row, pos.Column] = true;

                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsValidPosition(pos) && IsThereEnemy(pos)) mat[pos.Row, pos.Column] = true;

                if (Position.Row == 3)
                {
                    var left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsValidPosition(left) && IsThereEnemy(left) &&
                        Board.GetPiece(left) == Match.VulnerableEnPassant) mat[left.Row - 1, left.Column] = true;

                    var right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsValidPosition(right) && IsThereEnemy(right) &&
                        Board.GetPiece(right) == Match.VulnerableEnPassant) mat[right.Row - 1, right.Column] = true;
                }
            }

            else
            {
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.IsValidPosition(pos) && Free(pos)) mat[pos.Row, pos.Column] = true;

                pos.SetValues(Position.Row + 2, Position.Column);
                var p2 = new Position(Position.Row + 1, Position.Column);
                if (Board.IsValidPosition(p2) && Free(p2) && Board.IsValidPosition(pos) && Free(pos) &&
                    Movements == 0) mat[pos.Row, pos.Column] = true;

                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsValidPosition(pos) && IsThereEnemy(pos)) mat[pos.Row, pos.Column] = true;

                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsValidPosition(pos) && IsThereEnemy(pos)) mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }

        public void Passant(bool[,] mat)
        {
            if (Position.Row == 4)
            {
                var left = new Position(Position.Row, Position.Column - 1);
                if (Board.IsValidPosition(left) && IsThereEnemy(left) && Board.GetPiece(left) == Match.VulnerableEnPassant)
                    mat[left.Row + 1, left.Column] = true;

                var right = new Position(Position.Row, Position.Column + 1);
                if (Board.IsValidPosition(right) && IsThereEnemy(right) &&
                    Board.GetPiece(right) == Match.VulnerableEnPassant) mat[right.Row + 1, right.Column] = true;
            }
        }
       
        public override string ToString()
        {
            return "P";
        }
    }
}