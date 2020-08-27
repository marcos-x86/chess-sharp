using System.Linq;

namespace Chess.Pieces.Validators
{
    public abstract class Validator
    {
        protected internal Position Position { get; set; }
        protected internal Player Player { get; set; }
        protected internal bool IsFirstMovement { get; set; }

        protected Validator(Board board)
        {
            Board = board;
        }

        private Board Board { get; }

        public bool CanMoveTo(Position pos)
        {
            return FindAvailablePositions()[pos.Row, pos.Column];
        }

        public bool IsMovable()
        {
            var movements = FindAvailablePositions();
            return movements.Cast<bool>().Any(position => position);
        }

        public abstract bool[,] FindAvailablePositions();

        protected bool IsPositionCandidate(Position pos)
        {
            if (!IsValidPosition(pos)) return false;
            var piece = Board.GetPiece(pos);
            return IsFreePosition(pos) || !piece.Player.Color.Equals(Player.Color);
        }

        protected bool IsEnemyOnPosition(Position pos)
        {
            if (!IsValidPosition(pos)) return false;
            var piece = Board.GetPiece(pos);
            return !IsFreePosition(pos) && !piece.Player.Color.Equals(Player.Color);
        }

        protected bool IsFreePosition(Position pos)
        {
            return IsValidPosition(pos) && Board.GetPiece(pos) is null;
        }

        protected bool IsValidPosition(Position pos)
        {
            return pos.Row >= 0 && pos.Row < Board.Dimension && pos.Column >= 0 && pos.Column < Board.Dimension;
        }
    }
}