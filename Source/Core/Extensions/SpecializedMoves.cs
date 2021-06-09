using System;
using System.Collections.Generic;
using Core.Abstractions;

namespace Core.Extensions
{
    /// <summary>
    /// Provides extension methods for special <see cref="Move"/> instances 
    /// that requires additional information, such as en passant, and castles 
    /// </summary>
    public static class SpecializedMoves
    {
        /// <summary>
        /// According with <paramref name="moveEntries"/>, checks if
        /// <paramref name="piece"/> has moved.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="moveEntries">A list of moves previously processed.</param>
        /// <returns></returns>
        public static bool HasMoved(this IPiece piece, List<MoveEntry> moveEntries) 
            => throw new NotImplementedException();

        //TODO: Check signature
    }
}