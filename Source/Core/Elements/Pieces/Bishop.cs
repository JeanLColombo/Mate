using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Extensions;

namespace Core.Elements.Pieces
{
    /// <summary>
    /// Implements the <see cref="Bishop"/> piece.
    /// </summary>
    public class Bishop : Piece
    {
        /// <summary>
        /// Creates a <see cref="Bishop"/> piece of given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">True for white. Black otherwise.</param>
        /// <returns></returns>
        public Bishop(bool color) : base(color) {}

        /// <summary>
        /// Returns all moves available for a <see cref="Bishop"/> based on a board <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position) => 
            new Through[]{Through.MainDiagonal, Through.OppositeDiagonal}
                .SelectMany(o => new[]{true, false}
                    .SelectMany(s => new[]{(o, s)}))
                .SelectMany(os => this.Attack(os.o, os.s, position))
                .ToList();
    }
}