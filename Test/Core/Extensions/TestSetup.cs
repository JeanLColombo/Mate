using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements;
using Mate.Core.Extensions;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Extensions
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
            Assert.Single(board.Position);
        }

        [Fact]
        public void TestAddPieceToOccupiedSquare()
        {
            var board = new Board();
            var square = new Square(Files.a, Ranks.one);

            Assert.True(board.AddPiece<MockedPiece>(square, false));
            Assert.False(board.AddPiece<MockedPiece>(square, true));
            Assert.False(board.Position[square].Color);
            Assert.Single(board.Position);
        }

        [Fact]
        public void TestAddPieceToNullSquare()
        {
            var board = new Board();

            Assert.False(board.AddPiece<MockedPiece>(null, true));
            Assert.Empty(board.Position.Values.Where(p=> p is not null).ToList());
        }

        [Fact]
        public void TestAddPieceInChess()
        {
            var chess = new MockedChess();
            var piece = new MockedPiece(true);
            var square = new Square(Files.a, Ranks.one);

            Assert.True(chess.AddPiece(square, piece));

            Assert.False(chess.AddPiece(square, piece));

            Assert.Single(chess.Position);

            Assert.Equal(piece, chess.Position[square]);

        }

        [Fact]
        public void TestRemovePieceFromChess()
        {
            var occupiedSquare = new Square(Files.a, Ranks.one);
            var emptySquare = new Square(Files.b, Ranks.two);
            var chess = new MockedChess(new Dictionary<Square, IPiece>() {
                {occupiedSquare, new MockedPiece(false)}
                });

            IPiece nullPiece;
            IPiece boardPiece;

            Assert.False(chess.RemovePiece(emptySquare, out nullPiece));

            Assert.Null(nullPiece);

            Assert.True(chess.Position.ContainsKey(occupiedSquare));

            Assert.True(chess.RemovePiece(occupiedSquare, out boardPiece));

            Assert.NotNull(boardPiece);

            Assert.True(boardPiece is MockedPiece);

            Assert.False(boardPiece.Color);

            Assert.Empty(chess.Position);

        }


        [Fact]
        public void TestCopyEmptyPosition()
        {
            var b1 = new Board();
            var b2 = new Board(b1.Position);

            Assert.Empty(b2.Position);
        }

        [Fact]
        public void TestCopy()
        {
            var b1 = new Board();

            b1.AddPiece<MockedPiece>(new Square(Files.a, Ranks.one), true);
            b1.AddPiece<MockedRoyalPiece>(new Square(Files.h, Ranks.eight), false);

            var b2 = new Board(b1.Position);

            AssertTestCopies(b2);

            Assert.NotSame(b1, b2);
            Assert.NotSame(b1.Position, b2.Position);
        }

        [Fact]
        public void TestCopyOfBoardThatCeasesToExist()
        {
            var b1 = new Board();

            {
                var b2 = new Board();

                b1.AddPiece<MockedPiece>(new Square(Files.a, Ranks.one), true);
                b1.AddPiece<MockedRoyalPiece>(new Square(Files.h, Ranks.eight), false);

                b1.Copy(b2.Position);
            }

            AssertTestCopies(b1);
        }

        private void AssertTestCopies(Board b)
        {
            Assert.Equal(2, b.Position.Count);

            Assert.True(b.Position[new Square(Files.a, Ranks.one)].Color);
            Assert.False(b.Position[new Square(Files.h, Ranks.eight)].Color);

            Assert.True(b.Position[new Square(Files.a, Ranks.one)] is MockedPiece);
            Assert.True(b.Position[new Square(Files.h, Ranks.eight)] is MockedRoyalPiece);
        }
    }
}