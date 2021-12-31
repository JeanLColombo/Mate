using System.Collections.Generic;
using Mate.Core.Abstractions;


namespace Mate.Core.Elements.Pieces
{
    /// <summary>
    /// Implements the <see cref="King"/> piece.
    /// </summary>
    public class King : Royalty
    {
        /// <summary>
        /// Creates a <see cref="King"/> piece of given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">True for white. Black otherwise.</param>
        /// <returns></returns>
        public King(bool color) : base(color) {}

        /// <summary>
        /// Returns all moves available for a <see cref="King"/> based on a board <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position) =>
            RoyalAttack(position, 1);
    }
}