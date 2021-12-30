using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Games;
using Mate.Core.Elements.Rules;
using Mate.Tests.Core.Elements.Rules;

namespace Mate.Tests.Core.Elements.Games
{
    public class TestStandard 
    {
        [Fact]
        public void TestConstructor()
        {
            IGame game = new Standard<Classical>();

            AssertGame(game, 0, 20, 0, true);
        }

        [Fact]
        public void TestProcessMove()
        {
            IGame game = new Standard<Classical>();

            var move = game.AvailableMoves()
                .Where(m => m.ToSquare.IsSameSquareAs(
                    new Square(Files.e, Ranks.four)))
                .Single();
                
            Assert.True(game.ProcessMove(move));

            AssertGame(game, 0, 20, 0, false);

            Assert.Single(game.MoveEntries);
            Assert.Equal(move, game.MoveEntries.Last().Move);

            Assert.False(game.ProcessMove(move));
        }

        [Fact]
        public void TestGame()
        {
            Assert.True(false);

            // Set a new standard game of classical chess.
            IGame game = new Standard<Classical>();

            // Load game data
            var gameData = TestClassical.GameOfChessData;



        }

        private void AssertGame(
            IGame game,
            int score,
            int availableMoves,
            uint numberOfMoves,
            bool player)
        {
            Assert.Equal(score, game.Score);
            Assert.Equal(availableMoves, game.AvailableMoves().Count);
            Assert.Equal(numberOfMoves, game.MoveCount);
            Assert.Equal(player, game.CurrentPlayer);
        }
    }
}