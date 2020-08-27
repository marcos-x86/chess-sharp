namespace Chess.Pieces.Validators
{
    public class KingValidator : Validator
    {
        public KingValidator(Board board) : base(board)
        {
        }

        public override bool[,] FindAvailablePositions()
        {
            var availablePositions = new bool[Board.Dimension, Board.Dimension];
            var upperPosition = new Position(Position.Row - 1, Position.Column);
            var lowerPosition = new Position(Position.Row + 1, Position.Column);
            var rightPosition = new Position(Position.Row, Position.Column + 1);
            var leftPosition = new Position(Position.Row, Position.Column - 1);
            var upperLeftDiagonalPosition = new Position(Position.Row - 1, Position.Column - 1);
            var upperRightDiagonalPosition = new Position(Position.Row - 1, Position.Column + 1);
            var lowerLeftDiagonalPosition = new Position(Position.Row + 1, Position.Column - 1);
            var lowerRightDiagonalPosition = new Position(Position.Row + 1, Position.Column + 1);

            if (IsValidPosition(upperRightDiagonalPosition))
                availablePositions[upperRightDiagonalPosition.Row, upperRightDiagonalPosition.Column] =
                    IsPositionCandidate(upperRightDiagonalPosition);

            if (IsValidPosition(upperLeftDiagonalPosition))
                availablePositions[upperLeftDiagonalPosition.Row, upperLeftDiagonalPosition.Column] =
                    IsPositionCandidate(upperLeftDiagonalPosition);

            if (IsValidPosition(lowerLeftDiagonalPosition))
                availablePositions[lowerLeftDiagonalPosition.Row, lowerLeftDiagonalPosition.Column] =
                    IsPositionCandidate(lowerLeftDiagonalPosition);

            if (IsValidPosition(lowerRightDiagonalPosition))
                availablePositions[lowerRightDiagonalPosition.Row, lowerRightDiagonalPosition.Column] =
                    IsPositionCandidate(lowerRightDiagonalPosition);

            if (IsValidPosition(upperPosition))
                availablePositions[upperPosition.Row, upperPosition.Column] = IsPositionCandidate(upperPosition);

            if (IsValidPosition(lowerPosition))
                availablePositions[lowerPosition.Row, lowerPosition.Column] = IsPositionCandidate(lowerPosition);

            if (IsValidPosition(rightPosition))
                availablePositions[rightPosition.Row, rightPosition.Column] = IsPositionCandidate(rightPosition);

            if (IsValidPosition(leftPosition))
                availablePositions[leftPosition.Row, leftPosition.Column] = IsPositionCandidate(leftPosition);

            return availablePositions;
        }
    }
}