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
        /// Return available castling options for <paramref name="piece"/>, given
        /// a <paramref name="position"/> and <paramref namw="moveEntries"/>.
        /// </summary>
        /// <param name="piece">Must be <see cref="King"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static IReadOnlyCollection<Move> Castle(
            this IPiece piece, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries)
        {
            throw new NotImplementedException();
        }
    }
}