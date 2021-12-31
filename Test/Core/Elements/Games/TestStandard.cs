using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Games;
using Mate.Core.Elements.Pieces;
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

            AssertGame(game, 0, 20, 0, true, Outcome.Game);
        }

        [Fact]
        public void TestProcessMove()
        {
            IGame game = new Standard<Classical>();

            // Get a list of several different moves
            var validMove = game.AvailableMoves()
                .Where(m => m.ToSquare.IsSameSquareAs(
                    new Square(Files.e, Ranks.four)))
                .Single();

            var outOfOrderMove = game.AvailableMoves()
                .Where(m => m.ToSquare.IsSameSquareAs(
                    new Square(Files.b, Ranks.four)))
                .Single();

            var errorMove = validMove;

            var invalidMove = new Move(
                new Square(Files.a, Ranks.seven),
                new Square(Files.a, Ranks.three),
                MoveType.Normal);

            // Process a valid move
            Assert.True(game.ProcessMove(validMove));

            // Process an white move on black turn
            Assert.False(game.ProcessMove(outOfOrderMove));

            // Process a move from an unoccupied square
            Assert.Throws<KeyNotFoundException>(() => game.ProcessMove(errorMove));

            // Process an invalid move
            Assert.False(game.ProcessMove(invalidMove));

            // It is black's first turn - make some assertions
            AssertGame(game, 0, 20, 0, false, Outcome.Game);

            Assert.Single(game.MoveEntries);
            Assert.Equal(validMove, game.MoveEntries.Last().Move);
        }

        [Fact]
        public void TestGame()
        {
            // Set a new standard game of classical chess.
            IGame game = new Standard<Classical>();

            // Load game data
            var gameData = TestClassical.GameOfChessData;

            // Initialize assertion metrics
            int loop = 0;
            int score = 0;
            bool player = true;
            uint moves = 0;
            Outcome outcome = Outcome.Game;

            // Play the game
            Assert.All(gameData, tuple => {
                // Assert conditions
                AssertGame(game, score, game.AvailableMoves().Count, moves, player, outcome);

                // Get move data
                var move = tuple.Item1;
                var numberOfPieces = tuple.Item4;
                var captured = tuple.Item3;

                // Process move
                Assert.True(game.ProcessMove(move));

                // Post-move assertions
                Assert.Equal(32, game.Position.Count + game.CapturedPieces.Count);
                Assert.Equal(numberOfPieces, game.Position.Count);

                // Update assertion metrics
                switch(captured)
                {
                    case Pawn p:
                        score += (captured.Color ? -1 : +1) * 1;
                        break;
                    case Knight n:
                    case Bishop b:
                        score += (captured.Color ? -1 : +1) * 3;
                        break;
                    case Rook r:
                        score += (captured.Color ? -1 : +1) * 5;
                        break;
                    case Queen q:
                        score += (captured.Color ? -1 : +1) * 9;
                        break;
                    default:
                        break;
                }

                player = !player;

                if (player) moves++;

                if (game.AvailableMoves().Count == 0) 
                    outcome = Outcome.Checkmate;
                else
                    outcome = Outcome.Game;

                loop++;
                
                if(loop == 5 || loop == 19 || loop == 25)
                    outcome = Outcome.Checked;
            });

            AssertGame(game, -17, 0, 16, true, outcome);
            Assert.Equal(Outcome.Checkmate, outcome);
        }

        //TODO: Test stalemate.

        private void AssertGame(
            IGame game,
            int score,
            int availableMoves,
            uint numberOfMoves,
            bool player,
            Outcome outcome)
        {
            Assert.Equal(score, game.Score);
            Assert.Equal(availableMoves, game.AvailableMoves().Count);
            Assert.Equal(numberOfMoves, game.MoveCount);
            Assert.Equal(player, game.CurrentPlayer);
            Assert.Equal(outcome, game.Outcome);
        }
    }
}