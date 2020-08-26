using Chess.Pieces;
using System;
using System.Collections.Generic;
using Chess.Throwables;

namespace Chess.Util
{
    public static class BoardUtils
    {
        private const int InitialIndex = 8;

        public static void Display(ChessGame game)
        {
            PrintCurrentBoard(game.Board);
            PrintCapturedPieces(game);
            switch (game.Status)
            {
                case GameStatus.Active:
                {
                    if (game.CurrentColorTurn.Equals(game.Player1.Color))
                        Console.WriteLine("Waiting for player 1: " + game.Player1.Name);
                    else
                        Console.WriteLine("Waiting for player 2: " + game.Player2.Name);

                    break;
                }
                case GameStatus.CheckMate:
                {
                    Console.WriteLine("Checkmate.");
                    var winnerName = game.CurrentColorTurn.Equals(game.Player1.Color)
                        ? game.Player1.Name
                        : game.Player2.Name;
                    Console.WriteLine("Winner: " + winnerName);
                    break;
                }
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

        public static void PrintCurrentBoard(Board board)
        {
            Console.WriteLine("Game board:");
            Console.WriteLine("    a    b    c    d    e    f    g    h");
            for (var i = 0; i < board.Columns; i++)
            {
                Console.WriteLine("  -----------------------------------------");
                Console.Write(InitialIndex - i + " |");
                for (var j = 0; j < board.Rows; j++)
                {
                    PrintSinglePiece(board.GetPiece(new Position(i, j)));
                    Console.Write(" |");
                }

                Console.WriteLine();
            }

            Console.WriteLine("  -----------------------------------------");
        }

        public static void PrintBoardWithPositions(Board board, bool[,] possiblePositions)
        {
            Console.WriteLine("Game board:");
            Console.WriteLine("===================================");
            Console.WriteLine("    a    b    c    d    e    f    g    h");
            for (var i = 0; i < board.Columns; i++)
            {
                Console.WriteLine("  -----------------------------------------");
                Console.Write(InitialIndex - i + " |");
                for (var j = 0; j < board.Rows; j++)
                {
                    if (possiblePositions[i, j])
                        Console.Write("** ");
                    else
                        PrintSinglePiece(board.GetPiece(new Position(i, j)));
                    Console.Write(" |");
                }

                Console.WriteLine();
            }

            Console.WriteLine("  -----------------------------------------");
        }

        public static void PrintSinglePiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write(piece);
                Console.Write(" ");
            }
        }

        public static Position ParsePosition(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 2)
                throw new GameException("Invalid input.");
            if (!char.IsLetter(input[0]) || !char.IsDigit(input[1]))
                throw new GameException("Bad input format.");
            return new Position(input[0].ToString(), int.Parse(input[1].ToString()));
        }

        public static void PrintCapturedPieces(ChessGame match)
        {
            Console.WriteLine("Captured Pieces:");

            if (match.CurrentColorTurn.Equals(match.Player1.Color))
            {
                Console.Write(match.Player1.Name + ": ");
                Console.WriteLine(string.Join(", ", match.TakenPieces(match.Player1.Color)));
            }
            else
            {
                Console.Write(match.Player2.Name + ": ");
                Console.WriteLine(string.Join(", ", match.TakenPieces(match.Player2.Color)));
            }
        }
    }
}