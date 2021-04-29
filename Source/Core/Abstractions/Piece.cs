using System.Linq;
using System.Collections.Generic;

namespace Core.Abstractions
{
    /// <summary>
    /// Proxies <see cref="IPiece"/> and hides its members.
    /// </summary>
    public abstract class Piece : IPiece
    {
        /// <summary>
        /// Associated color of <see cref="Piece"/>.
        /// </summary>
        /// <value><c>true</c> if the <see cref="Piece"/> is white. <c>false</c> otherwise.</value>
        public bool Color {get;}

        /// <summary>
        /// Return all <see cref="Move"/>'s availablre por <see cref="IPiece"/>.
        /// </summary>
        /// <value></value>
        public virtual IReadOnlyCollection<Move> AvailableMoves {get;} = 
            Enumerable.Empty<Move>().ToArray();


        /// <summary>
        /// Associate <see cref="IPiece.Color"/> to <see cref="Color"/>.
        /// </summary>
        bool IPiece.Color => Color;

        /// <summary>
        /// Associate <see cref="IPiece.AvailableMoves"/> to <see cref="AvailableMoves"/>.
        /// </summary>
        IReadOnlyCollection<Move> IPiece.AvailableMoves => AvailableMoves;
    }
}