using Chess.Constants;

namespace Chess.Pieces.Validators
{
    public class PawnValidator : Validator
    {
        public PawnValidator(Board board) : base(board)
        {
        }

        public override bool[,] FindAvailablePositions()
        {
            var availablePositions = new bool[Board.Dimension, Board.Dimension];

            if (Player.BoardPosition.Equals(BoardPosition.Lower))
            {
                var forwardPosition = new Position(Position.Row - 1, Position.Column);
                var firstForwardPosition = new Position(Position.Row - 2, Position.Column);
                var diagonalLeftPosition = new Position(Position.Row - 1, Position.Column - 1);
                var diagonalRightPosition = new Position(Position.Row - 1, Position.Column + 1);

                if (IsValidPosition(firstForwardPosition))
                    availablePositions[firstForwardPosition.Row, firstForwardPosition.Column] =
                        IsFreePosition(forwardPosition) && IsFreePosition(firstForwardPosition) && IsFirstMovement;

                if (IsValidPosition(forwardPosition))
                    availablePositions[forwardPosition.Row, forwardPosition.Column] = IsFreePosition(forwardPosition);

                if (IsValidPosition(diagonalLeftPosition))
                    availablePositions[diagonalLeftPosition.Row, diagonalLeftPosition.Column] =
                        IsEnemyOnPosition(diagonalLeftPosition);

                if (IsValidPosition(diagonalRightPosition))
                    availablePositions[diagonalRightPosition.Row, diagonalRightPosition.Column] =
                        IsEnemyOnPosition(diagonalRightPosition);
            }

            else
            {
                var forwardPosition = new Position(Position.Row + 1, Position.Column);
                var firstForwardPosition = new Position(Position.Row + 2, Position.Column);
                var diagonalLeftPosition = new Position(Position.Row + 1, Position.Column - 1);
                var diagonalRightPosition = new Position(Position.Row + 1, Position.Column + 1);

                if (IsValidPosition(firstForwardPosition))
                    availablePositions[firstForwardPosition.Row, firstForwardPosition.Column] =
                        IsFreePosition(forwardPosition) && IsFreePosition(firstForwardPosition) && IsFirstMovement;

                if (IsValidPosition(forwardPosition))
                    availablePositions[forwardPosition.Row, forwardPosition.Column] = IsFreePosition(forwardPosition);

                if (IsValidPosition(diagonalLeftPosition))
                    availablePositions[diagonalLeftPosition.Row, diagonalLeftPosition.Column] =
                        IsEnemyOnPosition(diagonalLeftPosition);

                if (IsValidPosition(diagonalRightPosition))
                    availablePositions[diagonalRightPosition.Row, diagonalRightPosition.Column] =
                        IsEnemyOnPosition(diagonalRightPosition);
            }

            return availablePositions;
        }
    }
}