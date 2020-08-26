namespace Chess.Pieces.Validators
{
    public class BishopValidator : Validator
    {
        public BishopValidator(Board board) : base(board)
        {
        }

        public override bool[,] FindAvailablePositions()
        {
            var availablePositions = new bool[Board.Dimension, Board.Dimension];
            var upperLeftDiagonalPosition = new Position(Position.Row - 1, Position.Column - 1);
            var upperRightDiagonalPosition = new Position(Position.Row - 1, Position.Column + 1);
            var lowerLeftDiagonalPosition = new Position(Position.Row + 1, Position.Column - 1);
            var lowerRightDiagonalPosition = new Position(Position.Row + 1, Position.Column + 1);

            while (IsPositionCandidate(upperRightDiagonalPosition))
            {
                availablePositions[upperRightDiagonalPosition.Row, upperRightDiagonalPosition.Column] = true;
                if (IsEnemyOnPosition(upperRightDiagonalPosition)) break;
                upperRightDiagonalPosition.Row -= 1;
                upperRightDiagonalPosition.Column += 1;
            }

            while (IsPositionCandidate(upperLeftDiagonalPosition))
            {
                availablePositions[upperLeftDiagonalPosition.Row, upperLeftDiagonalPosition.Column] = true;
                if (IsEnemyOnPosition(upperLeftDiagonalPosition)) break;
                upperLeftDiagonalPosition.Row -= 1;
                upperLeftDiagonalPosition.Column -= 1;
            }

            while (IsPositionCandidate(lowerLeftDiagonalPosition))
            {
                availablePositions[lowerLeftDiagonalPosition.Row, lowerLeftDiagonalPosition.Column] = true;
                if (IsEnemyOnPosition(lowerLeftDiagonalPosition)) break;
                lowerLeftDiagonalPosition.Row += 1;
                lowerLeftDiagonalPosition.Column -= 1;
            }

            while (IsPositionCandidate(lowerRightDiagonalPosition))
            {
                availablePositions[lowerRightDiagonalPosition.Row, lowerRightDiagonalPosition.Column] = true;
                if (IsEnemyOnPosition(lowerRightDiagonalPosition)) break;
                lowerRightDiagonalPosition.Row += 1;
                lowerRightDiagonalPosition.Column += 1;
            }

            return availablePositions;
        }
    }
}