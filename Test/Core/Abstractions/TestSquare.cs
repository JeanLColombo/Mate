using Mate.Core.Abstractions;
using Xunit;


namespace Mate.Tests.Core.Abstractions
{
    public class TestSquare
    {
        [Fact]
        public void TestSquareConstructor()
        {
            var s = new Square(Files.a, Ranks.one);
        }

        [Fact]
        public void TestConstructionFromSquare()
        {
            var s1 = new Square(Files.a, Ranks.one);
            var s2 = new Square(s1);

            Assert.Equal(s1.File, s2.File);
            Assert.Equal(s1.Rank, s2.Rank);
            Assert.False(s1 == s2);
        }

        [Fact]
        public void TestSquaresWithSameFiles()
        {
            var s1 = new Square(Files.a, Ranks.one);
            var s2 = new Square(Files.a, Ranks.two);

            Assert.True(s1.IsSameFileAs(s1));
            Assert.False(s1.IsSameSquareAs(s2));
        }    

        [Fact]
        public void TestSquaresWithSameRanks()
        {
            var s1 = new Square(Files.a, Ranks.one);
            var s2 = new Square(Files.b, Ranks.one);

            Assert.True(s1.IsSameRankAs(s1));
            Assert.False(s1.IsSameSquareAs(s2));
        } 

        [Fact]
        public void TestSameSquare()
        {
            var s1 = new Square(Files.a, Ranks.one);
            var s2 = new Square(Files.a, Ranks.one);

            Assert.True(s1.IsSameSquareAs(s2));
        } 

        [Fact]
        public void TestSquareColor()
        {
            var s1 = new Square(Files.a, Ranks.one);
            var s2 = new Square(Files.e, Ranks.four);

            Assert.False(s1.Color);
            Assert.True(s2.Color);
        }
    }
}