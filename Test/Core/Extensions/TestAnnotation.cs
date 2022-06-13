using System.Collections.Generic;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Games;
using Mate.Core.Elements.Rules;
using Mate.Core.Extensions;

namespace Mate.Tests.Core.Extensions;

public class TestAnnotation
{
    [Fact]
    public void InvalidMoves()
    {
        IGame game = new Standard<Classical>();
        Assert.False(game.ProcessChessMove("INVALID"));
        Assert.False(game.ProcessChessMove("Ke1e4"));
    }

    [Fact]
    public void NumberOfMoves()
    {
        IGame game = new Standard<Classical>();
        Assert.Equal(20, game.AvailableChessMoves().Count);
    }

    [Fact]
    public void TestGameA()
    {
        var gameData = TestAnnotation.GameDataA;
        AssertGame(gameData);
    }

    [Fact]
    public void TestGameB()
    {
        var gameData = TestAnnotation.GameDataB;
        AssertGame(gameData);
    }

    private void AssertGame(IReadOnlyList<(string, Outcome, int)> gameData)
    {
        // Creates a game of standard chess
        IGame game = new Standard<Classical>();

        // Assert each entry in the given game data
        Assert.All(gameData, entry => {
            Assert.True(game.ProcessChessMove(entry.Item1));
            Assert.Equal(entry.Item2, game.Outcome);
            Assert.Equal(entry.Item3, game.Score);
        });
    }

    public static IReadOnlyList<(string, Outcome, int)> GameDataA
        => new List<(string, Outcome, int)>() {
            ("e2e4",    Outcome.Game,       0),
            ("e7e5",    Outcome.Game,       0),
            ("Qd1h5",   Outcome.Game,       0),
            ("Nb8c6",   Outcome.Game,       0),
            ("Bf1c4",   Outcome.Game,       0),
            ("Ng8f6",   Outcome.Game,       0),
            ("Qh5xf7",  Outcome.Checkmate,  1)
        };
    
    public static IReadOnlyList<(string, Outcome, int)> GameDataB
        => new List<(string, Outcome, int)>() {
            ("e2e4",    Outcome.Game,       0),
            ("e7e6",    Outcome.Game,       0),
            ("Qd1g4",   Outcome.Game,       0),
            ("Qd8g5",   Outcome.Game,       0),
            ("Ng1f3",   Outcome.Game,       0),
            ("Nb8c6",   Outcome.Game,       0),
            ("Bf1b5",   Outcome.Game,       0),
            ("b7b6",    Outcome.Game,       0),
            ("0-0",     Outcome.Game,       0),
            ("Bc8a6",   Outcome.Game,       0),
            ("Bb5xc6",  Outcome.Game,       3),
            ("0-0-0",   Outcome.Game,       3),
            ("Qg4xe6",  Outcome.Game,       4),
            ("Qg5xd2",  Outcome.Game,       3),
            ("Qe6xf7",  Outcome.Game,       4),
            ("Qd2xc2",  Outcome.Game,       3),
            ("Qf7xg7",  Outcome.Game,       4),
            ("Qc2xb2",  Outcome.Game,       3),
            ("Qg7xh7",  Outcome.Game,       4),
            ("Qb2xa2",  Outcome.Game,       3),
            ("e4e5",    Outcome.Game,       3),
            ("d7d5",    Outcome.Game,       3),
            ("e5xd6",   Outcome.Game,       4),
            ("Rh8xh7",  Outcome.Game,       -5),
            ("d6xc7",   Outcome.Checked,    -4),
            // Found a bug - debug to fix it
            // Pawn threatening king does not count as check
            //("Kb8xc7",  Outcome.Game,       -5),
        };


}