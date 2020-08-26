using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class King : Piece, ICastling
    {
        public King(Player player, Validator validator) : base(player, validator)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            return Validator.FindAvailablePositions();
        }

        public void Castle()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"K{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}