using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    internal class Pawn : Piece, IPromotion
    {
        public Pawn(Player player, Validator validator) : base(player, validator)
        {
        }

        public override bool[,] GetAvailablePositions()
        {
            return Validator.FindAvailablePositions();
        }

        public void Promote()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"p{(Player.Color.Equals(Color.White) ? "W" : "B")}";
        }
    }
}