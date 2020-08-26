using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class Horse : Piece
    {
        public Horse(Player player, Validator validator) : base(player, validator)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            return Validator.FindAvailablePositions();
        }

        public override string ToString()
        {
            return $"H{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}