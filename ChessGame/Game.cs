using System;
using System.IO;
using Chess;

namespace Chess
{
    public enum GameStatus
    {
        WhiteWins,
        BlackWins,
        Draw,
        InProgress
    }
    public class Game
    {
        private WhitePlayer WhitePlayer;
        private BlackPlayer BlackPlayer;
        private IPlayer CurrentPlayer;
        public GameStatus GameStatus { get; private set; }
        private Board board;

        public Game()
        {
            GameStatus = GameStatus.InProgress;
            WhitePlayer = new WhitePlayer();
            BlackPlayer = new BlackPlayer();
            CurrentPlayer = WhitePlayer;
            board = new Board();
        }

        public IPlayer GetCurrentPlayer()
        {
            return CurrentPlayer;
        }

        public void MakeRound()
        {
            Console.Clear();
            board.DrawBoard();
            bool wasMoved = false;
            while (!wasMoved)
            {
                var (source, destination) = GetInputWithCheck();
                wasMoved = board.MovePiece(source, destination);
                if (!wasMoved)
                {
                    Console.Write("This piece can't move like that! ");
                }
            }
            PlayerChange();
        }

        private void PlayerChange()
        {
            if (CurrentPlayer == WhitePlayer)
            {
                CurrentPlayer = BlackPlayer;
            }
            else
            {
                CurrentPlayer = WhitePlayer;
            }
        }

        public Tuple<Position, Position> getMoveInput()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Please enter your move: ");
                var moveInput = Console.ReadLine();
                var sourceX = charTransformation(moveInput[0]) - 1;
                var sourceY = moveInput[1] - 48 - 1;

                var destinationX = charTransformation(moveInput[3]) - 1;
                var destinationY = moveInput[4] - 48 - 1;

                var source = new Position(sourceX, sourceY);
                var destination = new Position(destinationX, destinationY);
                return new Tuple<Position, Position>(source, destination);
            }
            catch(Exception e)
            {
                Console.WriteLine("Wrong format, please use format like this [A2-A3]");
                return getMoveInput();
            }
        }

        public Tuple<Position, Position> GetInputWithCheck()
        {
            do
            {
                var input = getMoveInput();
                if (board.GetPiece(input.Item1) != null)
                {
                    if (board.GetPiece(input.Item1).Color == CurrentPlayer.Color)
                    {
                        if (board.GetPiece(input.Item2) == null)
                        {
                            return input;
                        }
                        if (board.GetPiece(input.Item1).Color != board.GetPiece(input.Item2).Color)
                        {
                            return input;
                        }
                        Console.Write("You can't kill your piece! ");
                        continue;
                    }
                }
                Console.Write("It's not your piece! ");
                
            } while (true);
        }
        private int charTransformation(char c)
        {
            switch (c) {
                case 'A':
                case 'a':
                    return 1;
                case 'B':
                case 'b':
                    return 2;
                case 'C':
                case 'c':
                    return 3;
                case 'D':
                case 'd':
                    return 4;
                case 'E':
                case 'e':
                    return 5;
                case 'F':
                case 'f':
                    return 6;
                case 'G':
                case 'g':
                    return 7;
                case 'H':
                case 'h':
                    return 8;
                default:
                    throw new InvalidDataException("Wrong input received.");
            }
        }
    }

}