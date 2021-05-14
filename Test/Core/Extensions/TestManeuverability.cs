using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Core.Extensions;

namespace Tests.Core.Extensions
{
    public class TestManeuverability
    {
        [Fact]
        public void TestMovePlusNothing()
        {
            var s = new Square(Files.a, Ranks.one);

            Assert.True(s.MovePlus(0,0).IsSameSquareAs(s));
        }

        [Theory]
        [MemberData(nameof(MoveDataA))]
        public void TestMovePlusSquareExists(
            Square os,
            Square ds,
            int nf,
            int nr
        )
        {
            Assert.True(os.MovePlus(nf,nr).IsSameSquareAs(ds));
        }

        [Theory]
        [MemberData(nameof(MoveDataB))]
        public void TestMovePlusSquareNotExists(
            Square os,
            int nf,
            int nr
        )
        {
            Assert.Null(os.MovePlus(nf,nr));
        }

        public static IEnumerable<object[]> MoveDataA => new List<object[]>{
            new object[]
            {
                new Square(Files.a, Ranks.one),
                new Square(Files.b, Ranks.one),
                1,
                0
            },
            new object[]
            {
                new Square(Files.a, Ranks.one),
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
                new Square(Files.a, Ranks.one),
                -1,
                0
            },
            new object[]
            {
                new Square(Files.a, Ranks.one),
                0,
                -1
            }
        };
    }
}