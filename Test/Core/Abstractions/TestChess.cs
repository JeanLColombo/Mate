using System;
using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Tests.Core.Mocks;

namespace Tests.Core.Abstractions
{
    public class TestChess
    {
        [Fact]
        public void TestEmptyChessBoard()
        {
            IChess chess = new MockedChess();

            Assert.Empty(chess.MoveEntries);
            Assert.Empty(chess.Position);
        }

        [Fact]
        public void TestMockedChessOverrides()
        {
            var chess = new MockedChess();

            Assert.Empty(chess.AvailableMoves(true));
            Assert.Empty(chess.AvailableMoves(false));
            Assert.Empty(chess.AllMoves(true));
            Assert.Empty(chess.AllMoves(false));
        }

        [Fact]
        public void TestChessBoard()
        {
            IReadOnlyDictionary<Square,IPiece> position = new Dictionary<Square,IPiece>() 
            {
                {new Square(Files.a, Ranks.one  ), new MockedPiece(true)},
                {new Square(Files.b, Ranks.two  ), new MockedPiece(false)},
                {new Square(Files.c, Ranks.three), new MockedPiece(true)},
                {new Square(Files.d, Ranks.four ), new MockedPiece(false)},
                {new Square(Files.e, Ranks.five ), new MockedPiece(true)},
                {new Square(Files.f, Ranks.six  ), new MockedPiece(false)},
                {new Square(Files.g, Ranks.seven), new MockedPiece(true)},   
                {new Square(Files.h, Ranks.eight), new MockedPiece(false)},    
            };

            IChess chess = new MockedChess(position);

            Assert.Empty(chess.MoveEntries);
            Assert.Empty(chess.AvailableMoves(false));

            Assert.Equal(8, chess.Position.Count);
            Assert.All(
                position.Keys, 
                s => {
                    Assert.NotEqual(position[s], chess.Position[s]);
                    Assert.True(chess.Position[s] is MockedPiece);
                    if ((int)s.File % 2 == 0)
                        Assert.False(chess.Position[s].Color);
                    else
                        Assert.True(chess.Position[s].Color);
                }
            );
        }

        [Fact]
        public void TestPlaceAt()
        {
            Chess chess = new MockedChess();
            IPiece piece = new MockedPiece(true);
            Square square = new Square(Files.a, Ranks.one);

            chess.PlaceAt(square, piece);

            Assert.Single(chess.Position);
            Assert.True(piece == chess.Position[square]);
        }

        [Fact]
        public void TestPlaceAtOccupiedSquare()
        {
            Chess chess = new MockedChess();
            IPiece occupyingPiece = new MockedPiece(true);
            IPiece piece = new MockedPiece(false);
            Square square = new Square(Files.a, Ranks.one);

            chess.PlaceAt(square, occupyingPiece);

            Assert.Throws<ArgumentException>(() => chess.PlaceAt(square, piece));

            Assert.True(occupyingPiece == chess.Position[square]);
        }

        [Fact]
        public void TestClear()
        {
            Chess chess = new MockedChess();
            IPiece piece = new MockedPiece(false);
            Square square = new Square(Files.a, Ranks.one);

            chess.PlaceAt(square, piece);

            chess.Clear(square);

            Assert.Empty(chess.Position);

            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => chess.Position[square]);
        }

        [Fact]
        public void TestClearEmptySquare()
        {
            Chess chess = new MockedChess();
            Square square = new Square(Files.a, Ranks.one);

            Assert.Throws<ArgumentException>(() => chess.Clear(square));
        }

    }
}