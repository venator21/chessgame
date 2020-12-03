using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Chess;
using Xunit;

namespace ChessTest
{
    public class ChessBoardTest : IDisposable
    {

        public void Dispose()
        {
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(0,7)]
        [InlineData(1,1)]
        [InlineData(6,6)]
        [InlineData(7,7)]
        [InlineData(7,0)]
        [InlineData(4,6)]
        [InlineData(5,7)]
        public void BoardIsInitializedWithAllPieces(int x, int y)
        {
            Board newBoard = new Board();
            var fieldContent = newBoard.GetField(new Position(x,y));
            Assert.NotNull(fieldContent);
        }
        
        [Theory]
        [InlineData(3,4)]
        [InlineData(2,5)]
        [InlineData(2,2)]
        [InlineData(3,3)]
        [InlineData(7,5)]
        [InlineData(6,4)]
        [InlineData(1,5)]
        [InlineData(0,2)]
        public void BoardInitializesWithEmptyFieldsElsewhere(int x, int y)
        {
            Board newBoard = new Board();
            var fieldContent = newBoard.GetField(new Position(x,y));
            Assert.Null(fieldContent);
        }

        [Theory]
        [InlineData(0,1,0,2)]
        [InlineData(0,6,0,5)]
        public void PieceCanBeMoved(int sourceX, int sourceY, int destinationX, int destinationY)
        {
            Board newBoard = new Board();
            var source = new Position(sourceX, sourceY);
            var destination = new Position(destinationX, destinationY);
            
            var sourcePiece = newBoard.GetField(source);
            var moveResult = newBoard.MovePiece(source, destination);
            var destinationPiece = newBoard.GetField(destination);

            Assert.True(moveResult);
            Assert.Null(newBoard.GetField(source));
            Assert.Same(sourcePiece, destinationPiece);
            
        }
    }
}