using System;
using System.Collections.Generic;
using Core.Abstractions;
using Core.Elements;

namespace Core
{
    /// <summary>
    /// Implements <see cref="Chess"/>, and it's basic rules.
    /// </summary>
    public class Chess
    {

        /// <summary>
        /// Chessboard, invisible to users.
        /// </summary>
        /// <value></value>
        private Board Board {get;} = new Board();

        /// <summary>
        /// Creates a new <see cref="Chess"/> object, with no pieces.
        /// </summary>
        public Chess() {}

        /// <summary>
        /// Return a list of all moves available to <paramref name="player"/>.
        /// </summary>
        /// <param name="player">True for player with white pieces, false for player
        /// with black pieces.</param>
        /// <returns>A collection of available <see cref="Move"/>s.</returns>
        public IReadOnlyCollection<Move> AvailableMoves(bool player)
            => throw new NotImplementedException();

    }
}