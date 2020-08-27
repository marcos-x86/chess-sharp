using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class Rook : Piece, ICastling
    {
        public Rook(Player player, Validator validator) : base(player, validator)
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
            return $"R{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}