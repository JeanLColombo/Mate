using System.Collections.Generic;
using Mate.Core.Abstractions;


namespace Mate.Core.Elements.Pieces
{
    /// <summary>
    /// Implements the <see cref="Queen"/> piece.
    /// </summary>
    public class Queen : Royalty
    {
        /// <summary>
        /// Creates a <see cref="Queen"/> piece of given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">True for white. Black otherwise.</param>
        /// <returns></returns>
        public Queen(bool color) : base(color) {}

        /// <summary>
        /// Returns all moves available for a <see cref="Queen"/> based on a board <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position) =>
            RoyalAttack(position, 7);
    }
}