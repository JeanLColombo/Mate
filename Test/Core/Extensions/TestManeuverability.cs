using System;
using System.Collections.Generic;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Extensions;

namespace Mate.Tests.Core.Extensions
{
    public class TestManeuverability
    {
        [Fact]
        public void TestMovePlusNothing()
        {
            var s = squareAOne;
            Assert.True(s.MovePlus(0,0).IsSameSquareAs(s));
        }

        [Theory]
        [MemberData(nameof(MoveDataA))]
        public void TestMovePlusSquareExists(
            Square os,
            Square ds,
            int nf,
            int nr) 
            => Assert.True(os.MovePlus(nf,nr).IsSameSquareAs(ds));

        [Theory]
        [MemberData(nameof(MoveDataB))]
        public void TestMovePlusSquareNotExists(
            Square os,
            int nf,
            int nr) 
            => Assert.Null(os.MovePlus(nf,nr));
        

        [Fact]
        public void TestManeuverThroughFiles() =>
            Assert.True(
                squareAOne
                .Maneuver(Through.Files, 1)
                .IsSameSquareAs(
                    new Square(Files.b,Ranks.one)));

        [Fact]
        public void TestManeuverThroughRanks() =>
            Assert.True(
                squareAOne
                .Maneuver(Through.Ranks, 1)
                .IsSameSquareAs(
                    new Square(Files.a, Ranks.two)));

        [Fact]
        public void TestManeuverThroughMainDiagonal() =>
            Assert.True(
                squareAOne
                .Maneuver(Through.MainDiagonal, 2)
                .IsSameSquareAs(
                    new Square(Files.c, Ranks.three)));
        
        [Fact]
        public void TestManeuverThroughOppositeDiagonal() =>
            Assert.True(
                new Square(Files.c, Ranks.three)
                .Maneuver(Through.OppositeDiagonal, -2)
                .IsSameSquareAs(
                    new Square(Files.e, Ranks.one)));

        [Fact]
        public void TestManeuverThrowsException() =>
            Assert.Throws<ArgumentException>(
                () => squareAOne.Maneuver((Through)(-1), 0));

        private static Square squareAOne => new Square(Files.a, Ranks.one);

        public static IEnumerable<object[]> MoveDataA => new List<object[]>{
            new object[]
            {
                squareAOne,
                new Square(Files.b, Ranks.one),
                1,
                0
            },
            new object[]
            {
                squareAOne,
                new Square(Files.a, Ranks.five),
                0,
                4
            },
            new object[]
            {
                new Square(Files.e, Ranks.four),
                new Square(Files.d, Ranks.two),
                -1,
                -2
            }
        };

        public static IEnumerable<object[]> MoveDataB => new List<object[]>{
            new object[]
            {
                squareAOne,
                -1,
                0
            },
            new object[]
            {
                squareAOne,
                0,
                -1
            }
        };
    }
}