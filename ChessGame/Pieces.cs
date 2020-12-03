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
        // protected APiece(PieceType pieceType, Color color)
        // {
        //     PieceType = pieceType;
        //     Color = color;
        // }

        public PieceType PieceType { get; protected set; }
        public Color Color { get; protected set; }
        
    }

    public class King : APiece
    {
        public King(Color color)
        {
            PieceType = PieceType.King;
            Color = color;
        }
    }

    public class Queen : APiece
    {
        public Queen(Color color)
        {
            PieceType = PieceType.Queen;
            Color = color;
        }
    }

    public class Bishop : APiece
    {
        public Bishop(Color color)
        {
            PieceType = PieceType.Bishop;
            Color = color;
        }
    }

    public class Knight : APiece
    {
        public Knight(Color color)
        {
            PieceType = PieceType.Knight;
            Color = color;
        }
    }

    public class Rook : APiece
    {
        public Rook(Color color)
        {
            PieceType = PieceType.Rook;
            Color = color;
        }
    }

    public class Pawn : APiece
    {
        public Pawn(Color color)
        {
            PieceType = PieceType.Pawn;
            Color = color;
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