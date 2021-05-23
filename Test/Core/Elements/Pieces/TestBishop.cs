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

            board.AddPiece<Bishop>(SquareEFive, true);

            var moves = board.Position[SquareEFive].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(13, moves.Count);
            
            SquareEFive.Maneuver(Through.MainDiagonal, 7);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.e)
                .Select(i => new Square((Files)i , (Ranks)i)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enumerable.Range(-4,8)
                .Where(i => i !=0)
                .Select(i => SquareEFive.Maneuver(Through.OppositeDiagonal, i))
                .Where(s => s is not null)
                .ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFive, m.FromSquare));   
        }

        private Square SquareAOne => new Square(Files.a, Ranks.one);
        private Square SquareEFive => new Square(Files.e, Ranks.five);
    
    }
}
