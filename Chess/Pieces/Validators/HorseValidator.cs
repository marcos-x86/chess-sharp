namespace Chess.Pieces.Validators
{
    public class HorseValidator : Validator
    {
        public HorseValidator(Board board) : base(board)
        {
        }

        public override bool[,] FindAvailablePositions()
        {
            var availablePositions = new bool[Board.Dimension, Board.Dimension];
            var upperLeftPosition1 = new Position(Position.Row - 1, Position.Column - 2);
            var upperLeftPosition2 = new Position(Position.Row - 2, Position.Column - 1);
            var upperRightPosition1 = new Position(Position.Row - 1, Position.Column + 2);
            var upperRightPosition2 = new Position(Position.Row - 2, Position.Column + 1);
            var lowerLeftPosition1 = new Position(Position.Row + 1, Position.Column - 2);
            var lowerLeftPosition2 = new Position(Position.Row + 2, Position.Column - 1);
            var lowerRightPosition1 = new Position(Position.Row + 1, Position.Column + 2);
            var lowerRightPosition2 = new Position(Position.Row - 2, Position.Column + 1);

            availablePositions[upperLeftPosition1.Row, upperLeftPosition1.Column] =
                IsPositionCandidate(upperLeftPosition1);

            availablePositions[upperLeftPosition2.Row, upperLeftPosition2.Column] =
                IsPositionCandidate(upperLeftPosition2);

            availablePositions[upperRightPosition1.Row, upperRightPosition1.Column] =
                IsPositionCandidate(upperRightPosition1);

            availablePositions[upperRightPosition2.Row, upperRightPosition2.Column] =
                IsPositionCandidate(upperRightPosition2);

            availablePositions[lowerLeftPosition1.Row, lowerLeftPosition1.Column] =
                IsPositionCandidate(lowerLeftPosition1);

            availablePositions[lowerLeftPosition2.Row, lowerLeftPosition2.Column] =
                IsPositionCandidate(lowerLeftPosition2);

            availablePositions[lowerRightPosition1.Row, lowerRightPosition1.Column] =
                IsPositionCandidate(lowerRightPosition1);

            availablePositions[lowerRightPosition2.Row, lowerRightPosition2.Column] =
                IsPositionCandidate(lowerRightPosition2);

            return availablePositions;
        }
    }
}