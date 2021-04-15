using Core.Abstractions;
using System;
using Xunit;


namespace Tests.Abstractions
{
    public class TestPosition
    {
        [Fact]
        public void TestPositionConstructor()
        {
            var p = new Position(Files.a, Ranks.one);
        }

        [Fact]
        public void TestPositionsWithSameFiles()
        {
            var p1 = new Position(Files.a, Ranks.one);
            var p2 = new Position(Files.a, Ranks.two);

            Assert.True(p1.SameFile(p1));
            Assert.False(p1.SamePosition(p2));
        }    

        [Fact]
        public void TestPositionWithSameRanks()
        {
            var p1 = new Position(Files.a, Ranks.one);
            var p2 = new Position(Files.b, Ranks.one);

            Assert.True(p1.SameRank(p1));
            Assert.False(p1.SamePosition(p2));
        } 

        [Fact]
        public void TestSamePosition()
        {
            var p1 = new Position(Files.a, Ranks.one);
            var p2 = new Position(Files.a, Ranks.one);

            Assert.True(p1.SamePosition(p2));
        } 
    }
}