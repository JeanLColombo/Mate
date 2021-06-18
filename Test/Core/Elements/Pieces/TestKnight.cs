using System.Linq;
using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Elements.Pieces
{
    public class TestKnight
    {
        [Fact]
        public void TestKnightOnTheCenter()
        {
            var square = new Square(Files.e, Ranks.four);

            var moves = PlaceKnightsAt(square);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(8, moves.Count);
            Assert.Contains(new Square(Files.c, Ranks.three), toSquares);
            Assert.Contains(new Square(Files.c, Ranks.five), toSquares);
            Assert.Contains(new Square(Files.d, Ranks.two), toSquares);
            Assert.Contains(new Square(Files.d, Ranks.six), toSquares);
            Assert.Contains(new Square(Files.f, Ranks.two), toSquares);
            Assert.Contains(new Square(Files.f, Ranks.six), toSquares);
            Assert.Contains(new Square(Files.g, Ranks.three), toSquares);
            Assert.Contains(new Square(Files.g, Ranks.five), toSquares);  

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(square, m.FromSquare));
        }

        [Fact]
        public void TestKnightOnTheCorner()
        {
            var square = new Square(Files.a, Ranks.one);

            var moves = PlaceKnightsAt(square);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(2, moves.Count);
            Assert.Contains(new Square(Files.b, Ranks.three), toSquares);
            Assert.Contains(new Square(Files.c, Ranks.two), toSquares);
        }

        [Fact]
        public void TestKnightIsBlocked()
        {
            var moves = PlaceKnightsAt(
                new Square(Files.a, Ranks.one), 
                new Square(Files.b, Ranks.three));

            Assert.Single(moves);    
            Assert.True(moves.First().ToSquare.IsSameSquareAs(new Square(Files.c, Ranks.two)));    
        }

        [Fact]
        public void TestKnightAttack()
        {   
            var moves = PlaceKnightsAt(
                new Square(Files.a, Ranks.one), 
                new Square(Files.b, Ranks.three), 
                false);

            var captures = moves.Where(m => m.Type == MoveType.Capture).ToList();

            Assert.Equal(2, moves.Count);
            Assert.Single(captures);
            Assert.True(captures.First().ToSquare.IsSameSquareAs(new Square(Files.b, Ranks.three)));
        }

        private IReadOnlyCollection<Move> PlaceKnightsAt(
            Square square, 
            Square otherPiece = null,
            bool otherKnightColor = true)
        {
            var board = new Board();

            board.AddPiece<Knight>(square, true);
            board.AddPiece<MockedPiece>(otherPiece, otherKnightColor);

            return board.Position[square].AvailableMoves(board.Position).ToList();
        }
    }
}