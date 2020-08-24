namespace Chess.Pieces
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; }
        public int Movements { get; private set; }
        protected Board Board { get; }

        protected Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            Movements = 0;
        }

        public abstract bool[,] GetAvailablePositions();

        public void IncreaseMovCounter()
        {
            Movements++;
        }

        public void DecreaseMovCounter()
        {
            Movements--;
        }
        
        public bool CanMoveTo(Position pos)
        {
            return GetAvailablePositions()[pos.Row, pos.Column];
        }
        
        public bool IsMovable()
        {
            var movements = GetAvailablePositions();
            for (var i = 0; i < Board.Rows; i++)
            {
                for (var j = 0; j < Board.Columns; j++)
                    if (movements[i, j])
                        return true;
            }

            return false;
        }
    }
}