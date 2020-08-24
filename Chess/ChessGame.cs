using Chess.Pieces;
using System.Collections.Generic;
using Chess.Throwables;

namespace Chess
{
    public class ChessGame
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Color CurrentColorTurn { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }
        public GameStatus Status { get; set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _captured;

        public ChessGame(Player player1, Player player2)
        {
            Initialize(player1, player2);
        }

        public void Initialize(Player player1, Player player2)
        {
            Board = new Board();
            Player1 = player1;
            Player2 = player2;
            CurrentColorTurn = player1.Color;
            Status = GameStatus.Active;
            VulnerableEnPassant = null;
            _pieces = new HashSet<Piece>();
            _captured = new HashSet<Piece>();
            InitializeBoard();
        }

        public void MakeThePlay(Position origin, Position destination)
        {
            var capturedPiece = RunMovement(origin, destination);
            var p = Board.GetPiece(destination);

            if (p is Pawn)
            {
                
            
                if (p.Color == Player1.Color && destination.Row == 0 || p.Color == Color.Black && destination.Row == 7)
                {
                    p = Board.RemovePiece(destination);
                    _pieces.Remove(p);
                    Piece queen = new Queen(Board, p.Color);
                    Board.SetPiece(queen, destination);
                    _pieces.Add(queen);
                }
            }
            else
            {
                ChangePlayer();
            }
            if (p is Pawn && destination.Row == origin.Row - 2 || destination.Row == origin.Row + 2)
                VulnerableEnPassant = p;
            else
                VulnerableEnPassant = null;
        }


        public HashSet<Piece> TakenPieces(Color color)
        {
            var aux = new HashSet<Piece>();
            foreach (var x in _captured)
                if (x.Color == color)
                    aux.Add(x);
            return aux;
        }

        private void ChangePlayer()
        {
            CurrentColorTurn = CurrentColorTurn == Player1.Color ? Player2.Color : Player1.Color;
        }

        public Piece RunMovement(Position origin, Position destination)
        {
            var P = Board.RemovePiece(origin);
            P.IncreaseMovCounter();
            var capturedPiece = Board.RemovePiece(destination);
            Board.SetPiece(P, destination);
            if (capturedPiece != null) _captured.Add(capturedPiece);


            if (P is King && destination.Column == origin.Column + 2)
            {
                var originR = new Position(origin.Row, origin.Column + 3);
                var destinationR = new Position(origin.Row, origin.Column + 1);
                var R = Board.RemovePiece(originR);
                R.IncreaseMovCounter();
                Board.SetPiece(R, destinationR);
            }
            switch (P)
            {
                case King _ when destination.Column == origin.Column - 2:
                {
                    var originR = new Position(origin.Row, origin.Column - 4);
                    var destinationR = new Position(origin.Row, origin.Column - 1);
                    var r = Board.RemovePiece(originR);
                    r.IncreaseMovCounter();
                    Board.SetPiece(r, destinationR);
                    break;
                }
                case Pawn _:
                {
                    if (origin.Column != destination.Column && capturedPiece == null)
                    {
                        Position posP;
                        posP = P.Color == Player1.Color ? new Position(destination.Row + 1, destination.Column) : new Position(destination.Row - 1, destination.Column);
                        capturedPiece = Board.RemovePiece(posP);
                        _captured.Add(capturedPiece);
                    }

                    break;
                }
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            var P = Board.RemovePiece(destination);
            P.DecreaseMovCounter();
            if (capturedPiece != null)
            {
                Board.SetPiece(capturedPiece, destination);
                _captured.Remove(capturedPiece);
            }

            Board.SetPiece(P, origin);


            if (P is King && destination.Column == origin.Column + 2)
            {
                var originR = new Position(origin.Row, origin.Column + 3);
                var destinationR = new Position(origin.Row, origin.Column + 1);
                var R = Board.RemovePiece(destinationR);
                R.DecreaseMovCounter();
                Board.SetPiece(R, originR);
            }


            if (P is King && destination.Column == origin.Column - 2)
            {
                var originR = new Position(origin.Row, origin.Column - 4);
                var destinationR = new Position(origin.Row, origin.Column - 1);
                var R = Board.RemovePiece(destinationR);
                R.DecreaseMovCounter();
                Board.SetPiece(R, originR);
            }


            if (P is Pawn)
                if (origin.Column != destination.Column && capturedPiece == VulnerableEnPassant)
                {
                    var pawn = Board.RemovePiece(destination);
                    Position posP;
                    if (P.Color == Player1.Color)
                        posP = new Position(3, destination.Column);
                    else
                        posP = new Position(4, destination.Column);
                    Board.SetPiece(pawn, posP);
                }
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.SetPiece(piece, new Position(column.ToString(), row));
            _pieces.Add(piece);
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            var aux = new HashSet<Piece>();
            foreach (var x in _pieces)
                if (x.Color == color)
                    aux.Add(x);
            aux.ExceptWith(TakenPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            return color == Player1.Color ? Player2.Color : Player1.Color;
        }

        public void CheckOriginPosition(Position pos)
        {
            if (Board.GetPiece(pos) == null)
                throw new MoveException("No piece.");

            if (CurrentColorTurn != Board.GetPiece(pos).Color)
                throw new GameException("Invalid piece.");

            if (!Board.GetPiece(pos).IsMovable())
                throw new ChessException("Cannot move piece");
        }

        private Piece King(Color color)
        {
            foreach (var p in InGamePieces(color))
                if (p is King)
                    return p;
            return null;
        }

        public void ValidadeDestinationPosition(Position origin, Position destination)
        {
            if (!Board.GetPiece(origin).CanMoveTo(destination))
                throw new ChessException("Invalid destination position!");
        }

        private void InitializeBoard()
        {
            InitializePlayer1Pieces();
            InitializePlayer2Pieces();
        }

        private void InitializePlayer1Pieces()
        {
            PutNewPiece('a', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('b', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('c', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('d', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('e', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('f', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('g', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('h', 2, new Pawn(Board, Player1.Color, this));
            PutNewPiece('a', 1, new Rook(Board, Player1.Color));
            PutNewPiece('b', 1, new Horse(Board, Player1.Color));
            PutNewPiece('c', 1, new Bishop(Board, Player1.Color));
            PutNewPiece('d', 1, new Queen(Board, Player1.Color));
            PutNewPiece('e', 1, new King(Board, Player1.Color, this));
            PutNewPiece('f', 1, new Bishop(Board, Player1.Color));
            PutNewPiece('g', 1, new Horse(Board, Player1.Color));
            PutNewPiece('h', 1, new Rook(Board, Player1.Color));
        }

        private void InitializePlayer2Pieces()
        {
            PutNewPiece('a', 8, new Rook(Board, Player2.Color));
            PutNewPiece('b', 8, new Horse(Board, Player2.Color));
            PutNewPiece('c', 8, new Bishop(Board, Player2.Color));
            PutNewPiece('d', 8, new Queen(Board, Player2.Color));
            PutNewPiece('e', 8, new King(Board, Player2.Color, this));
            PutNewPiece('f', 8, new Bishop(Board, Player2.Color));
            PutNewPiece('g', 8, new Horse(Board, Player2.Color));
            PutNewPiece('h', 8, new Rook(Board, Player2.Color));
            PutNewPiece('a', 7, new Pawn(Board, Player2.Color, this));
            PutNewPiece('b', 7, new Pawn(Board, Player2.Color, this));
            PutNewPiece('c', 7, new Pawn(Board, Player2.Color, this));
            PutNewPiece('d', 7, new Pawn(Board, Player2.Color, this));
            PutNewPiece('e', 7, new Pawn(Board, Player2.Color, this));
            PutNewPiece('f', 7, new Pawn(Board, Player2.Color, this));
            PutNewPiece('g', 7, new Pawn(Board, Player2.Color, this));
            PutNewPiece('h', 7, new Pawn(Board, Player2.Color, this));
        }
    }
}