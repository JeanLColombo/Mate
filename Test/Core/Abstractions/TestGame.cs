using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Pieces;
using Mate.Core.Elements.Rules;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Abstractions
{
    public class TestGame
    {
        [Theory]
        [MemberData(nameof(GameDataA))]
        public void TestWithEmptyMockedChess(
            int moveOrder,
            bool player
        )
        {
            try
            {
                IGame game = new MockedGame(
                    moveOrder, 
                    player, 
                    new MockedChess());

                var move = new Move(
                    new Square(Files.a, Ranks.one),
                    new Square(Files.b, Ranks.two),
                    MoveType.Normal);

                Assert.Equal(Outcome.Game, game.Outcome);
                Assert.Equal(moveOrder, game.MoveCount);
                Assert.Equal(player, game.CurrentPlayer);
                Assert.False(game.ProcessMove(move));
                Assert.Empty(game.CapturedPieces);
                Assert.Empty(game.MoveEntries);
                Assert.Empty(game.Position);
                Assert.Empty(game.Moves);
                Assert.Equal(0, game.Score);
                Assert.Empty(game.AvailableMoves());
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Assert.True(moveOrder < 0);
            }
        }

        [Fact]
        public void TestWithMockedChess()
        {
            IGame game = new MockedGame(0, true, new MockedChess(CustomPositionA));
            Assert.Equal(CustomPositionA.Keys, game.Position.Keys);
            Assert.All(CustomPositionA, kp =>
            {
                Assert.Equal(kp.Value.Color, game.Position[kp.Key].Color);
                Assert.Equal(kp.Value.GetType(), game.Position[kp.Key].GetType());
            });
            Assert.Equal(0, game.Score);
        }

        [Theory]
        [InlineData(true, 44)]
        [InlineData(false, 49)]
        public void TestWithCustomChess(
            bool player,
            int moveCount
        )
        {
            IGame game = new MockedGame(0, player, new Custom(CustomPositionA));

            var whiteMove = new Move(
                new Square(Files.a, Ranks.one), 
                new Square(Files.a, Ranks.two), 
                MoveType.Normal);

            var blackMove = new Move(
                new Square(Files.b, Ranks.seven), 
                new Square(Files.b, Ranks.six), 
                MoveType.Normal);

            var availableMove = player ? whiteMove : blackMove;
            var forbidenMove = player ? blackMove : whiteMove;

            Assert.Equal(moveCount, game.AvailableMoves().Count);
            Assert.True(game.ProcessMove(availableMove));
            Assert.False(game.ProcessMove(forbidenMove));
        }

        private IReadOnlyDictionary<Square, IPiece> CustomPositionA =>
            new Dictionary<Square, IPiece>() {
                {new Square(Files.a, Ranks.one),        new Rook(true)},
                {new Square(Files.a, Ranks.seven),      new Pawn(true)},
                {new Square(Files.b, Ranks.seven),      new Pawn(false)},
                {new Square(Files.c, Ranks.five),       new Pawn(true)},
                {new Square(Files.c, Ranks.eight),      new Bishop(false)},
                {new Square(Files.d, Ranks.four),       new Queen(true)},
                {new Square(Files.d, Ranks.five),       new Queen(false)},
                {new Square(Files.d, Ranks.eight),      new Knight(false)},
                {new Square(Files.e, Ranks.one),        new King(true)},
                {new Square(Files.e, Ranks.eight),      new King(false)},
                {new Square(Files.f, Ranks.one),        new Knight(true)},
                {new Square(Files.f, Ranks.four),       new Pawn(false)},
                {new Square(Files.g, Ranks.one),        new Bishop(true)},
                {new Square(Files.g, Ranks.two),        new Pawn(true)},
                {new Square(Files.h, Ranks.two),        new Pawn(false)},
                {new Square(Files.h, Ranks.eight),      new Rook(false)}
            };

        public static IEnumerable<object[]> GameDataA =>
            Enumerable
                .Range(-4, 10)
                .ToList()
                .SelectMany(v =>
                    Enumerable
                    .Range(0, 1)
                    .Select(n => n == 1)
                    .Select(p => new object[] { v, p })).ToArray();

    }
}