using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions
{
    public class TestSetup
    {
        [Fact]
        public void TestAddPiece()
        {
            var board = new Board();
            var square = new Square(Files.a, Ranks.one);

            Assert.True(board.AddPiece<MockedPiece>(square, true));
            Assert.True(board.Position[square] is MockedPiece);
            Assert.True(board.Position[square].Color);
        }

        [Fact]
        public void TestAddPieceToOccupiedSquare()
        {
            var board = new Board();
            var square = new Square(Files.a, Ranks.one);

            Assert.True(board.AddPiece<MockedPiece>(square, false));
            Assert.False(board.AddPiece<MockedPiece>(square, true));
            Assert.False(board.Position[square].Color);
        }
    }
}