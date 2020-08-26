using Chess.Pieces;
using System.Collections.Generic;
using Chess.Pieces.Validators;
using Chess.Throwables;

namespace Chess
{
    public class ChessGame
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Color CurrentColorTurn { get; private set; }
        public GameStatus Status { get; set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _taken;

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
            _pieces = new HashSet<Piece>();
            _taken = new HashSet<Piece>();
            InitializeBoard();
        }

        public void Move(Position origin, Position destination)
        {
            var piece = Board.UnsetPiece(origin);
            piece.SetPieceMovementFlag();
            var takenPiece = Board.UnsetPiece(destination);
            Board.SetPiece(piece, destination);
            if (takenPiece != null) _taken.Add(takenPiece);
        }


        public HashSet<Piece> TakenPieces(Color color)
        {
            var takenPieces = new HashSet<Piece>();
            foreach (var taken in _taken)
                if (taken.Player.Color == color)
                    takenPieces.Add(taken);
            return takenPieces;
        }

        private void PutNewPiece(char column, int row, Piece piece)
        {
            Board.SetPiece(piece, new Position(column.ToString(), row));
            _pieces.Add(piece);
        }

        private Color Opponent(Color color)
        {
            return color == Player1.Color ? Player2.Color : Player1.Color;
        }

        public void CheckPieceInPosition(Position pos)
        {
            if (Board.GetPiece(pos) == null)
                throw new MoveException("No piece.");

            if (CurrentColorTurn != Board.GetPiece(pos).Player.Color)
                throw new GameException("Invalid piece.");

            if (!Board.GetPiece(pos).Validator.IsMovable())
                throw new MoveException("Cannot move piece");
        }

        public void ValidadeDestinationPosition(Position origin, Position destination)
        {
            if (!Board.GetPiece(origin).Validator.CanMoveTo(destination))
                throw new ChessException("Invalid destination position!");
        }

        private void InitializeBoard()
        {
            InitializePlayer1Pieces();
            InitializePlayer2Pieces();
        }

        private void InitializePlayer1Pieces()
        {
            PutNewPiece('a', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('b', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('c', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('d', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('e', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('f', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('g', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('h', 2, new Pawn(Player1, new PawnValidator(Board)));
            PutNewPiece('a', 1, new Rook(Player1, new RookValidator(Board)));
            PutNewPiece('b', 1, new Horse(Player1, new HorseValidator(Board)));
            PutNewPiece('c', 1, new Bishop(Player1, new BishopValidator(Board)));
            PutNewPiece('d', 1, new Queen(Player1, new QueenValidator(Board)));
            PutNewPiece('e', 1, new King(Player1, new KingValidator(Board)));
            PutNewPiece('f', 1, new Bishop(Player1, new BishopValidator(Board)));
            PutNewPiece('g', 1, new Horse(Player1, new HorseValidator(Board)));
            PutNewPiece('h', 1, new Rook(Player1, new RookValidator(Board)));
        }

        private void InitializePlayer2Pieces()
        {
            PutNewPiece('a', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('b', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('c', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('d', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('e', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('f', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('g', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('h', 7, new Pawn(Player2, new PawnValidator(Board)));
            PutNewPiece('a', 8, new Rook(Player2, new RookValidator(Board)));
            PutNewPiece('b', 8, new Horse(Player2, new HorseValidator(Board)));
            PutNewPiece('c', 8, new Bishop(Player2, new BishopValidator(Board)));
            PutNewPiece('d', 8, new Queen(Player2, new QueenValidator(Board)));
            PutNewPiece('e', 8, new King(Player2, new KingValidator(Board)));
            PutNewPiece('f', 8, new Bishop(Player2, new BishopValidator(Board)));
            PutNewPiece('g', 8, new Horse(Player2, new HorseValidator(Board)));
            PutNewPiece('h', 8, new Rook(Player2, new RookValidator(Board)));
        }

        private void ChangeCurrentPlayerColor()
        {
            CurrentColorTurn = CurrentColorTurn == Player1.Color ? Player2.Color : Player1.Color;
        }
    }
}