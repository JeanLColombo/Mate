using Core.Elements;
using Xunit;

namespace Tests.Core.Elements
{
    public class TestBoard
    {
        [Fact]
        public void TestBoardConstructor()
        {
            var b = new Board();
        }

        [Fact]
        public void TestBoardSize()
        {
            var b = new Board();

            Assert.Equal(64, b.Squares.Count);
        }

        //TODO: Change from list to dictionary - get elements via their file and ranks.
    }
}