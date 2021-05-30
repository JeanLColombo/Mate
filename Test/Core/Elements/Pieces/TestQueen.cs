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
    public class TestQueen
    {
        [Fact]
        public void TestStarOnTheBoard()
        {
            var board = new Board();

            board.AddPiece<Queen>(SquareEFive, true);
            
            board.AddPiece<MockedPiece>(new Square(Files.e, Ranks.six), true);
            board.AddPiece<MockedPiece>(new Square(Files.f, Ranks.six), false);
            board.AddPiece<MockedPiece>(new Square(Files.g, Ranks.five), true);
            board.AddPiece<MockedPiece>(new Square(Files.h, Ranks.two), false);
            board.AddPiece<MockedPiece>(new Square(Files.e, Ranks.two), true);
            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.one), false);
            board.AddPiece<MockedPiece>(new Square(Files.c, Ranks.five), true);
            board.AddPiece<MockedPiece>(new Square(Files.b, Ranks.eigth), false);

            var moves = board.Position[SquareEFive].AvailableMoves(board.Position);

            Assert.Equal(15, moves.Count);
            Assert.Equal(11, moves.Where(m => m.Type is MoveType.Normal).ToList().Count());
            Assert.Equal(4, moves.Where(m => m.Type is MoveType.Capture).ToList().Count());
            Assert.All(moves.Select(m => m.FromSquare), (s) => Assert.Equal(SquareEFive, s));

            Assert.All(board.Position.Where(p => p.Value.Color is false).Select(p => p.Key), 
                (s) => Assert.Contains(s, moves.Where(m => m.Type is MoveType.Capture).Select(m => m.ToSquare).ToList()));
        }

        private Square SquareEFive => new Square(Files.e, Ranks.five);
    }
}