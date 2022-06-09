using System.Collections.Generic;
using System.Linq;
using Mate.Core.Abstractions;
using Mate.Core.Notation;


namespace Mate.Core.Extensions;

/// <summary>
/// Provides extension methods for interfacing <see cref="Game"/> instances
/// with standard chess <see cref="string"/> notation.
/// </summary>
public static class Annotation
{
    /// <summary>
    /// Returns a dictionary of <see cref="string"/> mapping moves in a <paramref name="game"/>
    /// and their notational counterpart. 
    /// </summary>
    /// <param name="game">An <see cref="IGame"/> of chess.</param>
    /// <returns>A dictionary mapping <see cref="string"/> and <see cref="Move"/> instances.</returns>
    public static IReadOnlyDictionary<string, Move> AvailableChessMoves(this IGame game) =>
        game.AvailableMoves().ToDictionary(
            m => ((m.Type != MoveType.Castle) ? Conversion.PieceToNotation(game.Position[m.FromSquare]) : "") + Conversion.MoveToNotation(m),
            m => m);

    /// <summary>
    /// Process the given notational <paramref name="chessMove"/>. 
    /// </summary>
    /// <param name="game">An <see cref="IGame"/> of chess.</param>
    /// <param name="chessMove">A notational chess <see cref="Move"/>.</param>
    /// <returns><see langword="true"/> if the <paramref name="chessMove"/> was
    /// processed. Otherwise, return <see langword="false"/>.</returns>
    public static bool ProcessChessMove(this IGame game, string chessMove)
    {
        if (!game.AvailableChessMoves().TryGetValue(chessMove, out Move move))
            return false;

        return game.ProcessMove(move);
    }


    //TODO: Add unit tests.
}