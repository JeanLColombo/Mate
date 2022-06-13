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
            ("O-O",     Outcome.Game,       0),
            ("Bc8a6",   Outcome.Game,       0),
            ("Bb5xc6",  Outcome.Game,       3),
            ("O-O-O",   Outcome.Game,       3),
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
            ("d6xc7",   Outcome.Game,       -4),
            ("Kc8xc7",  Outcome.Game,       -5),
            ("g2g4",    Outcome.Game,       -5),
            ("Ba6xf1",  Outcome.Game,       -10),
            ("g4g5",    Outcome.Game,       -10),
            ("Kc7xc6",  Outcome.Game,       -13),
            ("g5g6",    Outcome.Game,       -13),
            ("Qa2xa1",  Outcome.Game,       -18),
            ("g6xh7",   Outcome.Game,       -13),
            ("Qa1xb1",  Outcome.Game,       -16),
            ("h7xg8=N", Outcome.Game,       -11),
            ("Qb1xc1",  Outcome.Game,       -14),
            ("Ng8e7",   Outcome.Checked,    -14),
            ("Bf8xe7",  Outcome.Game,       -17),
            ("h2h4",    Outcome.Game,       -17),
            ("a7a5",    Outcome.Game,       -17),
            ("h4h5",    Outcome.Game,       -17),
            ("a5a4",    Outcome.Game,       -17),
            ("h5h6",    Outcome.Game,       -17),
            ("a4a3",    Outcome.Game,       -17),
            ("h6h7",    Outcome.Game,       -17),
            ("a3a2",    Outcome.Game,       -17),
            ("h7h8=Q",  Outcome.Game,       -9),
            ("a2a1=B",  Outcome.Game,       -11),
            ("Qh8xa1",  Outcome.Game,       -8),
            ("Bf1g2",   Outcome.Checked,    -8),
            ("Kg1xg2",  Outcome.Game,       -5),
            ("b6b5",    Outcome.Game,       -5),
            ("Nf3d4",   Outcome.Checked,    -5),
            ("Rd8xd4",  Outcome.Game,       -8),
            ("Qa1xd4",  Outcome.Game,       -3),
            ("b5b4",    Outcome.Game,       -3),
            ("Qd4e4",   Outcome.Checked,    -3),
            ("Kc6b5",   Outcome.Game,       -3),
            ("Qe4xe7",  Outcome.Game,       0),
            ("b4b3",    Outcome.Game,       0),
            ("Qe7g5",   Outcome.Checked,    0),
            ("Kb5a4",   Outcome.Game,       0),
            ("Qg5xc1",  Outcome.Game,       9),
            ("b3b2",    Outcome.Game,       9),
            ("f2f4",    Outcome.Game,       9),
            ("b2xc1=R", Outcome.Game,       -4),
            ("f4f5",    Outcome.Game,       -4),
            ("Rc1g1",   Outcome.Checked,    -4),
            ("Kg2xg1",  Outcome.Game,       1),
            ("Ka4b5",   Outcome.Game,       1),
            ("Kg1f2",   Outcome.Game,       1),
            ("Kb5c6",   Outcome.Game,       1),
            ("Kf2f3",   Outcome.Game,       1),
            ("Kc6d7",   Outcome.Game,       1),
            ("Kf3f4",   Outcome.Game,       1),
            ("Kd7e8",   Outcome.Game,       1),
            ("f5f6",    Outcome.Game,       1),
            ("Ke8f7",   Outcome.Game,       1),
            ("Kf4f5",   Outcome.Game,       1),
            ("Kf7f8",   Outcome.Game,       1),
            ("f6f7",    Outcome.Game,       1),
            ("Kf8e7",   Outcome.Game,       1),
            ("Kf5g6",   Outcome.Game,       1),
            ("Ke7f8",   Outcome.Game,       1),
            ("Kg6f6",   Outcome.Stalemate,  1)
        };
}