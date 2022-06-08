using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Notation;

namespace Mate.Tests.Core.Notation
{
    public class TestHelper
    {
        [Theory]
        [InlineData("a1", Files.a, Ranks.one)]
        [InlineData("b1", Files.b, Ranks.one)]
        [InlineData("a2", Files.a, Ranks.two)]
        [InlineData("c3", Files.c, Ranks.three)]
        [InlineData("h8", Files.h, Ranks.eight)]
        public void TestSquareToNotation(string squareNotation, Files file, Ranks rank)
        {
            Assert.Equal(squareNotation, Helper.SquareToNotation(new Square(file, rank)));
        }
    }

}