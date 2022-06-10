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

}