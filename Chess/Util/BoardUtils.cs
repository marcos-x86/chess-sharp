using Chess.Pieces;
using System;
using System.Collections.Generic;
using Chess.Throwables;

namespace Chess.Util
{
    public static class BoardUtils
    {
        private const int InitialIndex = 8;

        public static void PrintBoard(ChessGame game)
        {
            PrintCurrentBoard(game.Board);
            switch (game.Status)
            {
                case GameStatus.Active:
                {
                    Console.WriteLine(game.CurrentColorTurn.Equals(game.Player1.Color)
                        ? $"Waiting for player 1: {game.Player1.Name} ({game.Player1.Color})"
                        : $"Waiting for player 2: {game.Player2.Name} ({game.Player2.Color})");
                    break;
                }
                case GameStatus.CheckMate:
                    break;
                case GameStatus.Check:
                    break;
                case GameStatus.Reset:
                    break;
                case GameStatus.Quit:
                    break;
                default:
                    throw new GameException("No valid status");
            }
        }

        private static void PrintCurrentBoard(Board board)
        {
            Console.WriteLine("Game board:");
            Console.WriteLine("    a    b    c    d    e    f    g    h");
            for (var x = 0; x < Board.Dimension; x++)
            {
                Console.WriteLine("  -----------------------------------------");
                Console.Write($"{InitialIndex - x} |");
                for (var y = 0; y < Board.Dimension; y++)
                {
                    PrintPiece(board.GetPiece(new Position(x, y)));
                    Console.Write(" |");
                }

                Console.WriteLine();
            }

            Console.WriteLine("  -----------------------------------------");
            Console.WriteLine("Reset game using 'reset' command any time.");
        }


        public static void PrintCandidatePositions(ChessGame game, Position origin)
        {
            var possiblePositions = game.Board.GetPiece(origin).GetAvailablePositions();
            var positions = new List<string>();
            for (var x = 0; x < Board.Dimension; x++)
            for (var y = 0; y < Board.Dimension; y++)
                if (possiblePositions[x, y])
                    positions.Add(new Position(x, y).ToString());
            Console.WriteLine($"Candidate positions for piece in {origin}:");
            Console.WriteLine(string.Join(", ", positions));
        }

        public static Position ParsePosition(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 5)
                throw new GameException("Invalid input.");
            if (!char.IsLetter(input[3]) || !char.IsDigit(input[2]))
                throw new GameException("Bad input format.");
            return new Position(input[3].ToString(), int.Parse(input[2].ToString()));
        }

        public static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Captured Pieces:");

            Console.WriteLine(game.CurrentColorTurn.Equals(game.Player1.Color)
                ? string.Join(", ", game.TakenPieces(game.Player1.Color))
                : string.Join(", ", game.TakenPieces(game.Player2.Color)));
        }

        private static void PrintPiece(Piece piece)
        {
            Console.Write(piece is null ? "   " : $"{piece} ");
        }
    }
}