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
        /// Return all basic <see cref="Move"/>'s available for <see cref="Piece"/> at
        /// a given <paramref name="position"/>.
        /// </summary>
        /// <param name="position">Dictionary containing <see cref="IPiece"/>'s at
        /// various <see cref="Square"/>'s</param>
        /// <returns></returns>
        public abstract IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position);


        /// <summary>
        /// Associate <see cref="IPiece.Color"/> to <see cref="Color"/>.
        /// </summary>
        bool IPiece.Color => Color;

        /// <summary>
        /// Associate <see cref="IPiece.AvailableMoves"/> to <see cref="AvailableMoves"/>.
        /// </summary>
        IReadOnlyCollection<Move> IPiece.AvailableMoves(IReadOnlyDictionary<Square,IPiece> p) 
            => AvailableMoves(p);
    }
}