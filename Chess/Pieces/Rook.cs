using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Player player, Validator validator) : base(player, validator)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            return Validator.FindAvailablePositions();
        }

        public override string ToString()
        {
            return $"R{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}