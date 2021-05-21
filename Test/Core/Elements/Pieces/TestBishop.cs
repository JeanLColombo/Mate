using System;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Elements.Pieces
{
    public class TestBishop
    {
        [Fact]
        public void TestBishopOnTheCenter()
        {
            var board = new Board();

            board.AddPiece<Bishop>(SquareEFour, true);

            var moves = board.Position[SquareEFour].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(14, moves.Count);
            
            //Enumerable.Range(-7, 14).Select(num)

            SquareEFour.Maneuver(Through.MainDiagonal, 7);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.e)
                .Select(f => new Square(f , Ranks.four)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enum.GetValues(typeof(Ranks)).Cast<Ranks>()
                .Where(r => r is not Ranks.four)
                .Select(r => new Square(Files.e , r)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));   
        }

        private Square SquareAOne => new Square(Files.a, Ranks.one);
        private Square SquareEFour => new Square(Files.e, Ranks.four);
    
    }
}
