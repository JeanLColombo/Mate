using System;
using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Elements;
using Core.Extensions;

namespace Tests.Core.Mocks.MoreExtensions
{
    /// <summary>
    /// Provide extension methods for testing multiple classes.
    /// </summary>
    internal static class Helper
    {
        internal static IReadOnlyDictionary<Square,IPiece> BuildMockedPosition(
            this IPiece piece,
            Square square,
            List<Tuple<Square, bool>> positions)
        {
            var pieces = new Dictionary<Square,IPiece>() {{square, piece}};

            positions.Select(p => pieces[p.Item1] = new MockedPiece(p.Item2)).ToList();

            return pieces;
        }

        internal static IReadOnlyCollection<Move> GetMovesFromMockedPosition(
            this IPiece piece,
            Square square,
            List<Tuple<Square, bool>> positions) =>
                piece.AvailableMoves(piece.BuildMockedPosition(square, positions));
    }

}