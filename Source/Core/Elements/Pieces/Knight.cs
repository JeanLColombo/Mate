using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Core.Elements.Pieces
{
    /// <summary>
    /// Implements the <see cref="Knight"/> piece.
    /// </summary>
    public class Knight : Piece
    {
        /// <summary>
        /// Creates a <see cref="Knight"/> piece of given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">True for white. Black otherwise.</param>
        /// <returns></returns>
        public Knight(bool color) : base(color)
        {
        }

        /// <summary>
        /// Returns all moves available for a <see cref="Knight"/> based on a board <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square, IPiece> position)
        {
            var square = this.GetSquareFrom(position);
            var moves = new List<Move>();

            if (square is null)
                return moves;

            foreach (int one in new int[] {1, -1})
                foreach (int two in new int[] {2, -2})
                {
                }

        

            throw new System.NotImplementedException();
        }

    }
}