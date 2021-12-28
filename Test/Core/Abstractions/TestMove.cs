
using System.Collections.Generic;
using Xunit;
using Mate.Core.Abstractions;

namespace Mate.Tests.Core.Abstractions
{
    public class TestMove
    {
        [Fact]
        public void TestConstructor()
        {
            var move = new Move(
                new Square(Files.a, Ranks.one),
                new Square(Files.b, Ranks.two),
                MoveType.Normal);
        }

        [Theory]
        [MemberData(nameof(MoveData))]
        public void TestEquals(
            Move moveA,
            Move moveB,
            bool areEqual) 
            => Assert.True(areEqual == moveA.Equals(moveB));

        [Fact]
        public void TestGetHashCode()
        {
            var move = new Move(
                new Square(Files.a, Ranks.one),
                new Square(Files.b, Ranks.two),
                MoveType.Normal);

            move.GetHashCode();
        }

        public static IEnumerable<object[]> MoveData => new []{ 
            new object[]
            {
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.a, Ranks.two),
                    MoveType.Normal),
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.a, Ranks.two),
                    MoveType.Normal),
                true
            },
            new object[]
            {
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.a, Ranks.two),
                    MoveType.Normal),
                new Move(
                    new Square(Files.h, Ranks.eight),
                    new Square(Files.a, Ranks.two),
                    MoveType.Normal),
                false 
            },
            new object[]
            {
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.a, Ranks.two),
                    MoveType.Normal),
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.b, Ranks.two),
                    MoveType.Normal),
                false 
            },
            new object[]
            {
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.a, Ranks.two),
                    MoveType.Normal),
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.a, Ranks.two),
                    MoveType.Capture),
                false 
            },
            new object[]
            {
                new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.a, Ranks.two),
                    MoveType.Normal),
                null,
                false 
            }
            
        };

    }
}