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
        /// A position on the <see cref="Board"/>.
        /// </summary>
        /// <value></value>
        IReadOnlyDictionary<Square,IPiece> Position { get; }
        
        /// <summary>
        /// A collection of all the move entries in a game o <see cref="Chess"/>.
        /// </summary>
        /// <value></value>
        IReadOnlyCollection<MoveEntry> MoveEntries { get; }

        /// <summary>
        /// Currently available moves to a player, based on the given 
        /// <paramref name="color"/> of their pieces.
        /// </summary>
        /// <param name="color">True for white, false for black.</param>
        /// <returns>A read-only collection of <see cref="Move"/> objects.</returns>
        IReadOnlyCollection<Move> AvailableMoves(bool color);
    }
}