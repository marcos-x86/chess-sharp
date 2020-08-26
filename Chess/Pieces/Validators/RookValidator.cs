using System;

namespace Chess.Pieces.Validators
{
    public class RookValidator : Validator
    {
        public RookValidator(Board board) : base(board)
        {
        }

        public override bool[,] FindAvailablePositions()
        {
            var availablePositions = new bool[Board.Dimension, Board.Dimension];
            var upperPosition = new Position(Position.Row - 1, Position.Column);
            var lowerPosition = new Position(Position.Row + 1, Position.Column);
            var rightPosition = new Position(Position.Row, Position.Column + 1);
            var leftPosition = new Position(Position.Row, Position.Column - 1);

            while (IsPositionCandidate(upperPosition))
            {
                availablePositions[upperPosition.Row, upperPosition.Column] = true;
                if (IsEnemyOnPosition(upperPosition)) break;
                upperPosition.Row -= 1;
            }

            while (IsPositionCandidate(lowerPosition))
            {
                availablePositions[lowerPosition.Row, lowerPosition.Column] = true;
                if (IsEnemyOnPosition(lowerPosition)) break;
                lowerPosition.Row += 1;
            }

            while (IsPositionCandidate(rightPosition))
            {
                availablePositions[rightPosition.Row, rightPosition.Column] = true;
                if (IsEnemyOnPosition(rightPosition)) break;
                rightPosition.Column += 1;
            }

            while (IsPositionCandidate(leftPosition))
            {
                availablePositions[leftPosition.Row, leftPosition.Column] = true;
                if (IsEnemyOnPosition(leftPosition)) break;
                leftPosition.Column -= 1;
            }

            return availablePositions;
        }
    }
}