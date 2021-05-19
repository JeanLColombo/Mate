using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Core.Extensions.Pieces
{
    /// <summary>
    /// Implements the <see cref="Rook"/> piece.
    /// </summary>
    public class Rook : Piece
    {
        /// <summary>
        /// Creates a <see cref="Rook"/> piece of given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">True for white. Black otherwise.</param>
        /// <returns></returns>
        public Rook(bool color) : base(color) {}

        /// <summary>
        /// Returns all moves available for a <see cref="Rook"/> based on a board <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position) => 
            new Through[]{Through.Files, Through.Ranks}
                .SelectMany(o => new[]{true, false}
                    .SelectMany(s => new[]{(o, s)}))
                .SelectMany(os => this.Attack(os.o, os.s, position))
                .ToList();
    }
}