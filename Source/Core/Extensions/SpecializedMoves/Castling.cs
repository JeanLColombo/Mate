using System;
using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;

namespace Core.Extensions.SpecializedMoves
{
    /// <summary>
    /// Provides extension methods for castling, both king and queen side.
    /// </summary>
    public static class Castling
    {
        /// <summary>
        /// Return available castling options for <paramref name="king"/>, given
        /// a <paramref name="position"/> and <paramref name="moveEntries"/>.
        /// </summary>
        /// <param name="king">Must be <see cref="King"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static IReadOnlyCollection<Move> Castle(
            this IPiece king, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries)
        {
            var moves = new HashSet<Move>();

            var square = ((Piece)king).GetSquareFrom(position);    

            if (
                king is not King || 
                square is null  ||
                king.HasMoved(position, moveEntries)) 
                return moves;

            var rookSquares = position
                .Where(kv => kv.Value.Color == king.Color && kv.Value is Rook)
                .Where(kv => !kv.Value.HasMoved(position, moveEntries))
                .Select(kv => kv.Key)
                .ToList();    

            if (rookSquares.Count == 0) return moves;



            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all <see cref="Square"/>'s on the same rank between two files.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private static IReadOnlyCollection<Square> SquaresInBetweenFiles(
            this Square s1, 
            Square s2)
        {
            //(s1.IsSameRankAs(s2)) ? s1.Maneuver(Through.Files, (int)s2.Rank - (int)s1.Rank);
            throw new NotImplementedException();
        }
    }
}