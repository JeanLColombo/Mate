using Xunit;
using Mate.Core.Elements;

namespace Mate.Tests.Core.Elements
{
    public class TestBoard
    {
        [Fact]
        public void TestBoardConstructor()
        {
            var b = new Board();
        }

        [Fact]
        public void TestEmptyBoard()
        {
            var b = new Board();

            Assert.Empty(b.Position);
        }
    }
}