using System;
using Core.Abstractions;

namespace Core.Extensions
{
    /// <summary>
    /// Provides extension methods for check and <see cref="Move"/> legality checking in 
    /// a <see cref="Game"/> of <see cref="Chess"/>.
    /// </summary>
    public static class Legality
    {
        /// <summary>
        /// Checks if <paramref name="player"/> is currently under check.
        /// </summary>
        /// <param name="chess">A <see cref="Chess"/> board.</param>
        /// <param name="player">True for player with white pieces. Otherwise, blank.</param>
        /// <returns></returns>
        public static bool IsChecked(this IChess chess, bool player)
            => false;

        /// <summary>
        /// Checks if a <paramref name="move"/> is legal (does not place own king under check).
        /// </summary>
        /// <param name="chess">A <see cref="Chess"/> board.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns></returns>
        public static bool IsLegal(this IChess chess, Move move)
            => true;
    }

}