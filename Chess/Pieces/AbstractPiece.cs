using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        protected bool IsFirstMovement { get; private set; }
        public Validator Validator { get; protected set; }
        public Player Player { get; }

        protected Piece(Player player, Validator validator)
        {
            Position = null;
            Player = player;
            IsFirstMovement = true;
            validator.Player = Player;
            validator.Position = Position;
            validator.IsFirstMovement = IsFirstMovement;
            Validator = validator;
        }

        public abstract bool[,] GetAvailablePositions();

        public void SetPieceMovementFlag()
        {
            IsFirstMovement = false;
        }
    }
}