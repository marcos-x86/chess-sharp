using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Player player, Validator validator) : base(player, validator)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            return Validator.FindAvailablePositions();
        }

        public override string ToString()
        {
            return $"Q{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}