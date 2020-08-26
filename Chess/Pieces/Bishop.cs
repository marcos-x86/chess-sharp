using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Player player, Validator validator) : base(player, validator)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            return Validator.FindAvailablePositions();
        }

        public override string ToString()
        {
            return $"B{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}