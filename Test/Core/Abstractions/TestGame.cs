using Xunit;
using Mate.Core.Abstractions;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Abstractions
{
    public class TestGame
    {
        // TODO: Make this a theory.
        [Fact]
        public void TestConstructor()
        {
            var moveOrder = 5;
            var player = true;
            IGame game = new MockedGame((uint)moveOrder, player, new MockedChess());

            var move = new Move(
                new Square(Files.a, Ranks.one),
                new Square(Files.b, Ranks.two),
                MoveType.Normal);

            Assert.Equal((uint)moveOrder, game.Move);
            Assert.Equal(player, game.CurrentPlayer);
            Assert.False(game.ProcessMove(move));
            Assert.Empty(game.CapturedPieces);
            Assert.Empty(game.MoveEntries);
            Assert.Empty(game.Position);
            Assert.Empty(game.Moves);
            Assert.Empty(game.AvailableMoves());
        }

    }
}