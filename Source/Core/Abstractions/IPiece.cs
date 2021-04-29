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
        /// Return all <see cref="Move"/>'s availablre por <see cref="IPiece"/>.
        /// </summary>
        /// <value></value>
        IReadOnlyCollection<Move> AvailableMoves { get; }
    }
}