using Chess.Pieces.Validators;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public Position Position
        {
            get => _position;
            set
            {
                _position = value;
                Validator.Position = value;
            }
        }

        public Validator Validator { get; }
        public Player Player { get; }
        private bool IsFirstMovement { get; set; }
        private Position _position;

        protected Piece(Player player, Validator validator)
        {
            Player = player;
            IsFirstMovement = true;
            validator.Player = Player;
            validator.Position = Position;
            validator.IsFirstMovement = IsFirstMovement;
            Validator = validator;
        }

        public void SetPieceMovementFlag()
        {
            IsFirstMovement = false;
            Validator.IsFirstMovement = false;
        }

        public abstract bool[,] GetAvailablePositions();
    }
}