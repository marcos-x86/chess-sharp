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

            availablePositions[upperRightDiagonalPosition.Row, upperRightDiagonalPosition.Column] =
                IsPositionCandidate(upperRightDiagonalPosition);

            availablePositions[upperLeftDiagonalPosition.Row, upperLeftDiagonalPosition.Column] =
                IsPositionCandidate(upperLeftDiagonalPosition);

            availablePositions[lowerLeftDiagonalPosition.Row, lowerLeftDiagonalPosition.Column] =
                IsPositionCandidate(lowerLeftDiagonalPosition);

            availablePositions[lowerRightDiagonalPosition.Row, lowerRightDiagonalPosition.Column] =
                IsPositionCandidate(lowerRightDiagonalPosition);

            availablePositions[upperPosition.Row, upperPosition.Column] = IsPositionCandidate(upperPosition);

            availablePositions[lowerPosition.Row, lowerPosition.Column] = IsPositionCandidate(lowerPosition);

            availablePositions[rightPosition.Row, rightPosition.Column] = IsPositionCandidate(rightPosition);

            availablePositions[leftPosition.Row, leftPosition.Column] = IsPositionCandidate(leftPosition);

            return availablePositions;
        }
    }
}