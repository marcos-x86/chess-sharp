using Chess.Pieces;
using System;
using Chess.Constants;
using Chess.Throwables;
using Chess.Util;

namespace Chess
{
    internal static class MainProgram
    {
        private static void Main(string[] args)
        {
            NewGame();
        }

        private static void NewGame()
        {
            var activeGame = true;
            while (activeGame)
            {
                PrintStartMenu();
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        activeGame = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void StartGame()
        {
            try
            {
                var player1 = PrintSetupPlayer1();
                var player2 = PrintSetupPlayer2(player1);
                var game = new ChessGame(player1, player2);
                while (game.Status.Equals(GameStatus.Active))
                    try
                    {
                        Console.Clear();
                        BoardUtils.PrintBoard(game);
                        BoardUtils.PrintCapturedPieces(game);
                        Console.WriteLine("Choose a piece to move (format: S([row][column]):");
                        Console.Write("Origin:");
                        var input = Console.ReadLine();
                        CheckGameToBeReset(input, game, player1, player2);
                        var origin = BoardUtils.ParsePosition(input);
                        game.CheckPieceInPosition(origin);
                        Console.Clear();
                        BoardUtils.PrintBoard(game);
                        BoardUtils.PrintCapturedPieces(game);
                        BoardUtils.PrintCandidatePositions(game, origin);
                        Console.Write("Target (format: T([row][column]): ");
                        var inputDestiny = Console.ReadLine();
                        CheckGameToBeReset(inputDestiny, game, player1, player2);
                        var destination = BoardUtils.ParsePosition(inputDestiny);
                        game.ValidadeDestinationPosition(origin, destination);
                        game.Move(origin, destination);
                    }
                    catch (ChessException e)
                    {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }
                    catch (GameException e)
                    {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }
                    catch (MoveException e)
                    {
                        Console.Write(e.Message);
                        Console.ReadLine();
                    }

                Console.Clear();
                BoardUtils.PrintBoard(game);
            }
            catch (ChessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (GameException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MoveException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CheckGameToBeReset(string input, ChessGame game, Player player1, Player player2)
        {
            if (!input.Equals("reset")) return;
            game.Initialize(player1, player2);
            game.Status = GameStatus.Reset;
            throw new GameException("Resetting Game");
        }

        private static void PrintStartMenu()
        {
            Console.WriteLine("Chess-sharp");
            Console.WriteLine("1 - New Game");
            Console.WriteLine("2 - Exit");
        }

        private static Player PrintSetupPlayer1()
        {
            Console.WriteLine("Enter Player 1 Information");
            Console.WriteLine("Name:");
            var namePlayer1 = Console.ReadLine();
            Console.WriteLine("Choose player color");
            Console.WriteLine("1 - Black");
            Console.WriteLine("2 - White");
            var colorOption = Console.ReadLine();
            Console.WriteLine("Choose player position on board:");
            Console.WriteLine("1 - Lower");
            Console.WriteLine("2 - Upper");
            var boardPositionOption = Console.ReadLine();
            var colorPlayer1 = GetColorFromString(colorOption);
            var boarPositionPlayer1 = GetBoardPositionFromString(boardPositionOption);
            return new Player(namePlayer1, colorPlayer1, boarPositionPlayer1);
        }

        private static Player PrintSetupPlayer2(Player player)
        {
            Console.WriteLine("Enter Player 2 Information");
            Console.WriteLine("Name:");
            var namePlayer2 = Console.ReadLine();
            var colorPlayer2 = GetOppositeColor(player.Color);
            var boardPositionPlayer2 = GetOppositeBoardPosition(player.BoardPosition);
            Console.WriteLine($"Setting opposite color for player 2: ${colorPlayer2}");
            Console.WriteLine($"Setting opposite board position for player 2: ${boardPositionPlayer2}");
            return new Player(namePlayer2, colorPlayer2, boardPositionPlayer2);
        }

        private static Color GetColorFromString(string option)
        {
            switch (option)
            {
                case "1":
                    return Color.Black;
                case "2":
                    return Color.White;
                default:
                    Console.WriteLine("Choosing White as default.");
                    return Color.White;
            }
        }

        private static BoardPosition GetBoardPositionFromString(string option)
        {
            switch (option)
            {
                case "1":
                    return BoardPosition.Lower;
                case "2":
                    return BoardPosition.Upper;
                default:
                    Console.WriteLine("Choosing Lower as default.");
                    return BoardPosition.Lower;
            }
        }

        private static Color GetOppositeColor(Color color)
        {
            return color.Equals(Color.Black) ? Color.White : Color.Black;
        }

        private static BoardPosition GetOppositeBoardPosition(BoardPosition position)
        {
            return position.Equals(BoardPosition.Lower) ? BoardPosition.Upper : BoardPosition.Lower;
        }
    }
}