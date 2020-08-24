using Chess.Pieces;
using System;
using Chess.Throwables;

namespace Chess
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProgramGame();
        }

        public static void ProgramGame()
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

        public static void StartGame()
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
                        BoardUtils.Display(game);
                        Console.WriteLine("Choose a piece to move:");
                        Console.Write("Origin:");
                        var input = Console.ReadLine();
                        CheckGameToBeReset(input, game, player1, player2);
                        var origin = BoardUtils.ParsePosition(input);
                        game.CheckOriginPosition(origin);
                        var possiblePositions = game.Board.GetPiece(origin).GetAvailablePositions();
                        Console.Clear();
                        BoardUtils.PrintBoardWithPositions(game.Board, possiblePositions);
                        Console.Write("Destination: ");
                        var inputDestiny = Console.ReadLine();
                        CheckGameToBeReset(inputDestiny, game, player1, player2);
                        var destination = BoardUtils.ParsePosition(inputDestiny);
                        game.ValidadeDestinationPosition(origin, destination);
                        game.MakeThePlay(origin, destination);
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
                BoardUtils.Display(game);
            }
            catch (ChessException e)
            {
                Console.Write(e.Message);
            }
            catch (GameException e)
            {
                Console.Write(e.Message);
            }
            catch (MoveException e)
            {
                Console.Write(e.Message);
            }
        }

        private static void CheckGameToBeReset(string input, ChessGame game, Player player1, Player player2)
        {
            if (input == "reset")
            {
                game.Initialize(player1, player2);
                game.Status = GameStatus.Reset;
                throw new GameException("Resetting Game");
            }
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
            var colorPlayer1 = GetColorFromString(colorOption);
            return new Player(namePlayer1, colorPlayer1);
        }

        private static Player PrintSetupPlayer2(Player player)
        {
            Console.WriteLine("Enter Player 2 Information");
            Console.WriteLine("Name:");
            var namePlayer2 = Console.ReadLine();
            var colorPlayer2 = GetOppositeColor(player.Color);
            Console.WriteLine($"Setting opposite color for player 2: ${colorPlayer2}");
            return new Player(namePlayer2, colorPlayer2);
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

        private static Color GetOppositeColor(Color color)
        {
            return color.Equals(Color.Black) ? Color.White : Color.Black;
        }
    }
}