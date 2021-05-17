using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions
{
    public class TestAttacking
    {
        [Fact]
        public void TestAttackOnEmptySquare()
        {
            var piece = new MockedPiece(true);

            var m = piece.AttackSquare(
                new Square(Files.a, Ranks.two), 
                CreatePosition(piece));

            Assert.Equal(new Square(Files.a, Ranks.one), m.FromSquare);
            Assert.Equal(new Square(Files.a, Ranks.two), m.ToSquare);
            Assert.Equal(MoveType.Normal, m.Type);
        }

        [Fact]
        public void TestAttackOnSquareOcuppiedByOppositeColor()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                new Square(Files.b, Ranks.two), 
                CreatePosition(piece));

            Assert.Equal(new Square(Files.a, Ranks.one), m.FromSquare);
            Assert.Equal(new Square(Files.b, Ranks.two), m.ToSquare);
            Assert.Equal(MoveType.Capture, m.Type);
        }

        [Fact]
        public void TestAttackOnSquareOcuppiedBySameColor()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                new Square(Files.b, Ranks.one), 
                CreatePosition(piece));

            Assert.Null(m);
        }

        [Fact]
        public void TestAttackFromOffThePosition()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                new Square(Files.a, Ranks.two), 
                CreatePosition());

            Assert.Null(m);
        }

        [Fact]
        public void TestAttackNoSquares()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                null, 
                CreatePosition(piece));

            Assert.Null(m);
        }

        private IReadOnlyDictionary<Square,IPiece> CreatePosition(
            IPiece p = null) 
        {
            var position = new Dictionary<Square,IPiece>() { 
                {new Square(Files.b, Ranks.one), new MockedPiece(true)},
                {new Square(Files.b, Ranks.two), new MockedPiece(false)}};

            if (p is not null) position[new Square(Files.a, Ranks.one)] = p;

            return position;
        }
    }
}