using System;

namespace Chess
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();

            while (game.GameStatus == GameStatus.InProgress)
            {
                game.MakeRound();
            }

        }
    }
}