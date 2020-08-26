using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(Player player, Validator validator) : base(player, validator)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            return Validator.FindAvailablePositions();
        }

        public override string ToString()
        {
            return $"p{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}