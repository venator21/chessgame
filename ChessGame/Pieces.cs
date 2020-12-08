using System;

namespace Chess
{
    public enum PieceType
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn
    }
    public enum Color
    {
        White,
        Black
    }

    public abstract class APiece
    {
        public PieceType PieceType { get; protected set; }
        public Color Color { get; protected set; }

         public abstract bool CanMove(Position source, Position destination);


    }

    public class King : APiece
    {
        public King(Color color)
        {
            PieceType = PieceType.King;
            Color = color;
        }

        public override bool CanMove(Position source, Position destination)
        {
            var x = Math.Abs(source.X - destination.X);
            var y = Math.Abs(source.Y - destination.Y);
            if (x > 1)
                return false;

            if (y > 1)
                return false;

            return x + y <= 2;
        }
    }

    public class Queen : APiece
    {
        public Queen(Color color)
        {
            PieceType = PieceType.Queen;
            Color = color;
        }
        public override bool CanMove(Position source, Position destination)
        {
            var x = Math.Abs(source.X - destination.X);
            var y = Math.Abs(source.Y - destination.Y);
            return (x == 0 || y == 0) || (x == y);
        }
    }

    public class Bishop : APiece
    {
        public Bishop(Color color)
        {
            PieceType = PieceType.Bishop;
            Color = color;
        }
        public override bool CanMove(Position source, Position destination)
        {
            var x = Math.Abs(source.X - destination.X);
            var y = Math.Abs(source.Y - destination.Y);
            return x == y;
        }
    }

    public class Knight : APiece
    {
        public Knight(Color color)
        {
            PieceType = PieceType.Knight;
            Color = color;
        }
        public override bool CanMove(Position source, Position destination)
        {
            var x = Math.Abs(source.X - destination.X);
            var y = Math.Abs(source.Y - destination.Y);
            return (x == 1 && y == 2) || (x == 2 && y == 1);
        }
    }

    public class Rook : APiece
    {
        public Rook(Color color)
        {
            PieceType = PieceType.Rook;
            Color = color;
        }
        public override bool CanMove(Position source, Position destination)
        {
            var x = Math.Abs(source.X - destination.X);
            var y = Math.Abs(source.Y - destination.Y);
            return x == 0 || y == 0;
        }
    }

    public class Pawn : APiece
    {
        public Pawn(Color color)
        {
            PieceType = PieceType.Pawn;
            Color = color;
        }
        public override bool CanMove(Position source, Position destination)
        {
            int x;
            int y;

            if (this.Color == Color.White) {
                x = destination.X - source.X;
                y = destination.Y - source.Y;
            } else {
                x = source.X - destination.X;
                y = destination.Y - source.Y;
            }

            if (y == 1)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static class PieceFactory
    {
        public static APiece Create(Color color, PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.King:
                    return new King(color);
                case PieceType.Queen:
                    return new Queen(color);
                case PieceType.Bishop:
                    return new Bishop(color);
                case PieceType.Knight:
                    return new Knight(color);
                case PieceType.Rook:
                    return new Rook(color);
                case PieceType.Pawn:
                    return new Pawn(color);
                default:
                    throw new ArgumentException("Wrong piece type received.");
            }
        }
    }
}