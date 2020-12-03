using System;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace Chess
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public class Board
    {
        private APiece[,] grid;

        public Board()
        {
            grid = new APiece[8, 8];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            grid[0,0] = PieceFactory.Create(Color.White, PieceType.Rook);
            grid[1,0] = PieceFactory.Create(Color.White, PieceType.Knight);
            grid[2,0] = PieceFactory.Create(Color.White, PieceType.Bishop);
            grid[3,0] = PieceFactory.Create(Color.White, PieceType.Queen);
            grid[4,0] = PieceFactory.Create(Color.White, PieceType.King);
            grid[5,0] = PieceFactory.Create(Color.White, PieceType.Bishop);
            grid[6,0] = PieceFactory.Create(Color.White, PieceType.Knight);
            grid[7,0] = PieceFactory.Create(Color.White, PieceType.Rook);

            grid[0,7] = PieceFactory.Create(Color.Black, PieceType.Rook);
            grid[1,7] = PieceFactory.Create(Color.Black, PieceType.Knight);
            grid[2,7] = PieceFactory.Create(Color.Black, PieceType.Bishop);
            grid[3,7] = PieceFactory.Create(Color.Black, PieceType.Queen);
            grid[4,7] = PieceFactory.Create(Color.Black, PieceType.King);
            grid[5,7] = PieceFactory.Create(Color.Black, PieceType.Bishop);
            grid[6,7] = PieceFactory.Create(Color.Black, PieceType.Knight);
            grid[7,7] = PieceFactory.Create(Color.Black, PieceType.Rook);
            
            for (var x = 0; x < 8; x++) {
                grid[x,1] = PieceFactory.Create(Color.White, PieceType.Pawn);
            }

            for (var x = 0; x < 8; x++) {
                grid[x,6] = PieceFactory.Create(Color.Black, PieceType.Pawn);
            }
        }

        public ref APiece GetField(Position position)
        {
            return ref grid[position.X, position.Y];
        }

        public bool MovePiece(Position source, Position destination)
        {
            var sourcePiece = grid[source.X, source.Y];
            grid[destination.X, destination.Y] = grid[source.X, source.Y];
            grid[source.X, source.Y] = null;
            var destinationPiece = grid[destination.X, destination.Y];
            
            var isSuccessful = ReferenceEquals(sourcePiece, destinationPiece);
            return isSuccessful;
        }

        public void DrawBoard()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            for (var i = 7; i >= 0; i--)
            {
                var fieldNumber = i + 1;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" " + fieldNumber + "|");
                for (var j = 0; j < 8; j++)
                {
                    var p = GetField(new Position(j, i));
                    if (p == null) {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" " + "." + " ");
                        continue;
                    }
                    switch (p.PieceType) {
                        case PieceType.King:
                            Console.ForegroundColor = p.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
                            Console.Write(" K ");
                            break;
                        case PieceType.Queen:
                            Console.ForegroundColor = p.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
                            Console.Write(" Q ");
                            break;
                        case PieceType.Bishop:
                            Console.ForegroundColor = p.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
                            Console.Write(" B ");
                            break;
                        case PieceType.Knight:
                            Console.ForegroundColor = p.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
                            Console.Write(" N ");
                            break;
                        case PieceType.Rook:
                            Console.ForegroundColor = p.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
                            Console.Write(" R ");
                            break;
                        case PieceType.Pawn:
                            Console.ForegroundColor = p.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
                            Console.Write(" P ");
                            break;
                        default:
                            throw new ArgumentException("This is not a piece, cant draw non-existing piece.");
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("   _______________________ ");
            Console.WriteLine("    A  B  C  D  E  F  G  H ");
        }

    }
}