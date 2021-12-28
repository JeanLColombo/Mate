using System;
using System.Collections.Generic;
using System.Linq;
using Mate.Core.Elements;
using Mate.Core.Extensions;

namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Implements a <see cref="Piece"/> belonging to royalty.
    /// </summary>
    public abstract class Royalty : Piece
    {
        /// <summary>
        /// Creates a new <see cref="Piece"/> belonging to royalty.
        /// </summary>
        /// <param name="color">True for white. Black otherwise.</param>
        /// <returns></returns>
        public Royalty(bool color) : base(color) {}

        /// <summary>
        /// Attacks a certain <paramref name="numberOfSquares"/> <see cref="Through"/> 
        /// all directions, based on a given <paramref name="position"/>.
        /// </summary>
        /// <param name="position">An <see cref="Board.Position"/>.</param>
        /// <param name="numberOfSquares">A number of squares.</param>
        /// <returns></returns>
        protected IReadOnlyCollection<Move> RoyalAttack(IReadOnlyDictionary<Square,IPiece> position, uint numberOfSquares)
            => Enum.GetValues(typeof(Through)).Cast<Through>()
                .SelectMany(t => new[]{true, false}
                    .SelectMany(s => new[]{(t, s)}))
                .SelectMany(ts => this.Attack(ts.t, ts.s, position, numberOfSquares))
                .ToList();
    }
}