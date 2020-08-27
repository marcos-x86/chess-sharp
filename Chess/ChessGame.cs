using Chess.Pieces;
using System.Collections.Generic;
using System.Linq;
using Chess.Constants;
using Chess.Pieces.Validators;
using Chess.Throwables;

namespace Chess
{
    public class ChessGame
    {
        public Board Board { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Color CurrentColorTurn { get; private set; }
        public GameStatus Status { get; set; }
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
            CurrentColorTurn = GetWhiteColorPlayer().Color;
            Status = GameStatus.Active;
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
            ChangeCurrentPlayerColor();
        }


        public IEnumerable<Piece> TakenPieces(Color color)
        {
            var takenPieces = new HashSet<Piece>();
            foreach (var taken in _taken.Where(taken => taken.Player.Color == color))
                takenPieces.Add(taken);
            return takenPieces;
        }

        public void CheckPieceInPosition(Position pos)
        {
            if (Board.GetPiece(pos) is null)
                throw new MoveException("No piece.");

            if (CurrentColorTurn != Board.GetPiece(pos).Player.Color)
                throw new GameException("Invalid piece.");

            if (!Board.GetPiece(pos).Validator.IsMovable())
                throw new MoveException("Cannot move piece.");
        }

        public void ValidadeDestinationPosition(Position origin, Position destination)
        {
            if (!Board.GetPiece(origin).Validator.CanMoveTo(destination))
                throw new MoveException("Invalid destination position.");
        }

        private void PutPiece(char column, int row, Piece piece)
        {
            Board.SetPiece(piece, new Position(column.ToString(), row));
        }

        private void InitializeBoard()
        {
            InitializePlayer1Pieces();
            InitializePlayer2Pieces();
        }

        private void InitializePlayer1Pieces()
        {
            PutPiece('a', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('b', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('c', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('d', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('e', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('f', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('g', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('h', Player1.BoardPosition.GetPawnRow(), new Pawn(Player1, new PawnValidator(Board)));
            PutPiece('a', Player1.BoardPosition.GetInitialPiecesRow(), new Rook(Player1, new RookValidator(Board)));
            PutPiece('b', Player1.BoardPosition.GetInitialPiecesRow(), new Horse(Player1, new HorseValidator(Board)));
            PutPiece('c', Player1.BoardPosition.GetInitialPiecesRow(), new Bishop(Player1, new BishopValidator(Board)));
            PutPiece('d', Player1.BoardPosition.GetInitialPiecesRow(), new Queen(Player1, new QueenValidator(Board)));
            PutPiece('e', Player1.BoardPosition.GetInitialPiecesRow(), new King(Player1, new KingValidator(Board)));
            PutPiece('f', Player1.BoardPosition.GetInitialPiecesRow(), new Bishop(Player1, new BishopValidator(Board)));
            PutPiece('g', Player1.BoardPosition.GetInitialPiecesRow(), new Horse(Player1, new HorseValidator(Board)));
            PutPiece('h', Player1.BoardPosition.GetInitialPiecesRow(), new Rook(Player1, new RookValidator(Board)));
        }

        private void InitializePlayer2Pieces()
        {
            PutPiece('a', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('b', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('c', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('d', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('e', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('f', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('g', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('h', Player2.BoardPosition.GetPawnRow(), new Pawn(Player2, new PawnValidator(Board)));
            PutPiece('a', Player2.BoardPosition.GetInitialPiecesRow(), new Rook(Player2, new RookValidator(Board)));
            PutPiece('b', Player2.BoardPosition.GetInitialPiecesRow(), new Horse(Player2, new HorseValidator(Board)));
            PutPiece('c', Player2.BoardPosition.GetInitialPiecesRow(), new Bishop(Player2, new BishopValidator(Board)));
            PutPiece('d', Player2.BoardPosition.GetInitialPiecesRow(), new Queen(Player2, new QueenValidator(Board)));
            PutPiece('e', Player2.BoardPosition.GetInitialPiecesRow(), new King(Player2, new KingValidator(Board)));
            PutPiece('f', Player2.BoardPosition.GetInitialPiecesRow(), new Bishop(Player2, new BishopValidator(Board)));
            PutPiece('g', Player2.BoardPosition.GetInitialPiecesRow(), new Horse(Player2, new HorseValidator(Board)));
            PutPiece('h', Player2.BoardPosition.GetInitialPiecesRow(), new Rook(Player2, new RookValidator(Board)));
        }

        private void ChangeCurrentPlayerColor()
        {
            CurrentColorTurn = CurrentColorTurn == Player1.Color ? Player2.Color : Player1.Color;
        }

        private Player GetWhiteColorPlayer()
        {
            return Player1.Color.Equals(Color.White) ? Player1 : Player2;
        }
    }
}