using System.Collections.Generic;
using Mate.Core.Elements;

namespace Mate.Core.Abstractions
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

        /// <summary>
        /// Process a given <paramref name="move"/>. 
        /// </summary>
        /// <param name="move">A given <see cref="Move"/> instance. </param>
        /// <param name="piece">If the given <paramref name="move"/> removes a
        ///  piece from the game, <see langword="out"/> a reference to it.</param>
        /// <returns><see langword="true"/> if move is processed. 
        /// Otherwise, <see langword="false"/>.</returns>
        bool Process(Move move, out IPiece piece);
    }
}