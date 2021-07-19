using System.Collections.Generic;
using Core.Elements;

namespace Core.Abstractions
{
    /// <summary>
    /// <see cref="IChess"/> interface.
    /// </summary>
    public interface IChess
    {
        /// <summary>
        /// A collection of all the move entries in a game o <see cref="Chess"/>.
        /// </summary>
        /// <value></value>
        IReadOnlyCollection<MoveEntry> MoveEntries { get; }

        /// <summary>
        /// Currently available moves a player, based on the given 
        /// <paramref name="color"/> of their pieces.
        /// </summary>
        /// <param name="color">True for white, false for black.</param>
        /// <returns></returns>
        IReadOnlyCollection<Move> AvailableMoves(bool color);
    }
}