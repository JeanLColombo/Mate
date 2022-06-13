using System;
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
            AssertGame(game, 0, 20, 1, false, Outcome.Game);

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
            int moves = 0;
            Outcome outcome = Outcome.Game;
            int counter = 0;

            // Play the game
            Assert.All(gameData, tuple => {
                // Assert conditions
                AssertGame(game, score, game.AvailableMoves().Count, moves, player, outcome);

                // Get move data
                var move = tuple.Item1;
                var numberOfPieces = tuple.Item4;
                var captured = tuple.Item3;
                var pieceColor = game.Position[move.FromSquare].Color;

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

                // Fix score for promotions
                switch(move.Type)
                {
                    case MoveType.PromoteToKnight:
                    case MoveType.PromoteToBishop:
                        score += (pieceColor ? 1 : -1) * 2;
                        break;
                    case MoveType.PromoteToRook:
                        score += (pieceColor ? 1 : -1) * 4;
                        break;
                    case MoveType.PromoteToQueen:
                        score += (pieceColor ? 1 : -1) * 8;
                        break;
                    default:
                        break;
                }

                player = !player;

                if (!player) moves++;

                if (game.AvailableMoves().Count == 0) 
                    outcome = Outcome.Checkmate;
                else
                    outcome = Outcome.Game;

                loop++;
                
                if(loop == 5 || loop == 19 || loop == 25)
                    outcome = Outcome.Checked;
            });

            // Post-game assertions
            AssertGame(game, -19, 0, 17, true, outcome);
            Assert.Equal(Outcome.Checkmate, outcome);

            // Assert game.Moves
            Assert.Equal((int)moves, game.Moves.Count);
            Assert.All(game.Moves, moves =>
            {
                // Every player played each move
                Assert.Equal(2, moves.Count);

                Assert.All(moves, move =>
                {
                    // Assert every move
                    var moveEntry = game.MoveEntries.ElementAt(counter);

                    Assert.Equal(moveEntry.Move, move);
                    Assert.Equal(player, moveEntry.Position[move.FromSquare].Color);

                    // Update assertion metrics
                    counter++;
                    player = !player;
                });
            });
        }

        [Fact]
        public void TestStalemate()
        {
            // Prepare a classical standard game
            IGame game = new Standard<Classical>();

            // Load stalemate game data
            Assert.All(StalemateGameData, data =>
            {

                // Separate data
                var move = data.Item1;
                var outcome = data.Item2;
                var score = data.Item3;

                // Process move
                Assert.True(game.ProcessMove(move));

                // Make assertions
                Assert.Equal(outcome, game.Outcome);
                Assert.Equal(score, game.Score);
            });

            // Post-game assertions
            Assert.Empty(game.AvailableMoves());
            Assert.Equal(Outcome.Stalemate, game.Outcome);
            Assert.Equal(10, (int)game.MoveCount);
            Assert.Equal(10, game.Moves.Count);
            Assert.Single(game.Moves.Last());
        }

        private void AssertGame(
            IGame game,
            int score,
            int availableMoves,
            int numberOfMoves,
            bool player,
            Outcome outcome)
        {
            Assert.Equal(score, game.Score);
            Assert.Equal(availableMoves, game.AvailableMoves().Count);
            Assert.Equal(numberOfMoves, game.MoveCount);
            Assert.Equal(player, game.CurrentPlayer);
            Assert.Equal(outcome, game.Outcome);
        }

        public static IReadOnlyList<Tuple<Move, Outcome, int>> StalemateGameData 
            => new List<Tuple<Move, Outcome, int>>() {
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.e, Ranks.two),
                        new Square(Files.e, Ranks.three),
                        MoveType.Normal),
                    Outcome.Game,
                    0),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.a, Ranks.seven),
                        new Square(Files.a, Ranks.five),
                        MoveType.Rush),
                    Outcome.Game,
                    0),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.d, Ranks.one),
                        new Square(Files.h, Ranks.five),
                        MoveType.Normal),
                    Outcome.Game,
                    0),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.a, Ranks.eight),
                        new Square(Files.a, Ranks.six),
                        MoveType.Normal),
                    Outcome.Game,
                    0),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.h, Ranks.five),
                        new Square(Files.a, Ranks.five),
                        MoveType.Capture),
                    Outcome.Game,
                    1),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.h, Ranks.seven),
                        new Square(Files.h, Ranks.five),
                        MoveType.Rush),
                    Outcome.Game,
                    1),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.h, Ranks.two),
                        new Square(Files.h, Ranks.four),
                        MoveType.Rush),
                    Outcome.Game,
                    1),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.a, Ranks.six),
                        new Square(Files.h, Ranks.six),
                        MoveType.Normal),
                    Outcome.Game,
                    1),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.a, Ranks.five),
                        new Square(Files.c, Ranks.seven),
                        MoveType.Capture),
                    Outcome.Game,
                    2),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.f, Ranks.seven),
                        new Square(Files.f, Ranks.six),
                        MoveType.Normal),
                    Outcome.Game,
                    2),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.c, Ranks.seven),
                        new Square(Files.d, Ranks.seven),
                        MoveType.Capture),
                    Outcome.Checked,
                    3),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.e, Ranks.eight),
                        new Square(Files.f, Ranks.seven),
                        MoveType.Normal),
                    Outcome.Game,
                    3),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.d, Ranks.seven),
                        new Square(Files.b, Ranks.seven),
                        MoveType.Capture),
                    Outcome.Game,
                    4),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.d, Ranks.eight),
                        new Square(Files.d, Ranks.three),
                        MoveType.Normal),
                    Outcome.Game,
                    4),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.b, Ranks.seven),
                        new Square(Files.b, Ranks.eight),
                        MoveType.Capture),
                    Outcome.Game,
                    7),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.d, Ranks.three),
                        new Square(Files.h, Ranks.seven),
                        MoveType.Normal),
                    Outcome.Game,
                    7),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.b, Ranks.eight),
                        new Square(Files.c, Ranks.eight),
                        MoveType.Capture),
                    Outcome.Game,
                    10),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.f, Ranks.seven),
                        new Square(Files.g, Ranks.six),
                        MoveType.Normal),
                    Outcome.Game,
                    10),
                new Tuple<Move, Outcome, int>(
                    new Move(
                        new Square(Files.c, Ranks.eight),
                        new Square(Files.e, Ranks.six),
                        MoveType.Normal),
                    Outcome.Stalemate,
                    10)
            };
    }
}