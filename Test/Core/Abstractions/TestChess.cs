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
            Assert.Empty(chess.AvailableMoves(true));
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
    }
}