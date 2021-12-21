using System;
using System.Collections.Generic;
using System.Linq;
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

            Assert.Empty(chess.AllMoves(true));
            Assert.Empty(chess.AllMoves(false));

            Assert.Empty(chess.AvailableMoves(true));
            Assert.Empty(chess.AvailableMoves(false));

            Assert.False(chess.Process(
                new Move(
                    new Square(Files.a, Ranks.one), 
                    new Square(Files.a, Ranks.one), 
                    MoveType.Normal), 
                out IPiece piece));
            Assert.Null(piece);
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

        [Fact]
        public void TestAdd()
        {
            IChess chess = new MockedChess(new Dictionary<Square, IPiece>() {
                {new Square(Files.a, Ranks.one), new MockedPiece(true)}
            });
            var move = new Move(
                new Square(Files.a, Ranks.one), 
                new Square(Files.b, Ranks.two), 
                MoveType.Normal);
            var entry = new MoveEntry(move, chess.Position);
            ((Chess)chess).Add(entry);

            Assert.Single(chess.MoveEntries);
            Assert.Equal(chess.Position.Keys, chess.MoveEntries.Last().Position.Keys);
            Assert.All(chess.Position.Keys, k =>
            {
                Assert.True(chess.MoveEntries.Last().Position[k] is MockedPiece);
                Assert.True(chess.MoveEntries.Last().Position[k].Color);
            });
            Assert.Equal(move, chess.MoveEntries.Last().Move);
        }

    }
}