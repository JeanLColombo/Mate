using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Extensions;

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
        public Knight(bool color) : base(color) {}

        /// <summary>
        /// Returns all moves available for a <see cref="Knight"/> based on a board <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square, IPiece> position)
        {
            var square = this.GetSquareFrom(position);
            
            return new []{1, -1}
                .SelectMany(one => new []{2, -2}
                    .SelectMany(two => new [] {(one, two), (two, one)}))
                .Select(ns => square.MovePlus(ns.Item1, ns.Item2))
                .Select(s => this.AttackSquare(s, position))
                .Where(m => m is not null)
                .ToList();
        }
    }
}