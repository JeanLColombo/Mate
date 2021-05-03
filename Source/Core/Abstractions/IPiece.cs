using System.Collections.Generic;

namespace Core.Abstractions
{
    /// <summary>
    /// <see cref="Piece"/> interface.
    /// </summary>
    public interface IPiece
    {

        /// <summary>
        /// Associated color of <see cref="IPiece"/>.
        /// </summary>
        /// <value><c>true</c> if the <see cref="IPiece"/> is white. <c>false</c> otherwise.</value>
        bool Color {get;}


        /// <summary>
        /// Return all basic <see cref="Move"/>'s available for <see cref="IPiece"/> at
        /// a given <paramref name="position"/>.
        /// </summary>
        /// <param name="position">Dictionary containing <see cref="IPiece"/>'s at
        /// various <see cref="Square"/>'s.</param>
        /// <returns></returns>
        IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position);
    }
}