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
            var input = getMoveInput();
            board.MovePiece(input.Item1, input.Item2);
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