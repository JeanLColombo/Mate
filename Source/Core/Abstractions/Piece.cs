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
        /// Creates a new <see cref="Piece"/> object, of a given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">White if <see cref="true"/>. Black otherwise.</param>
        public Piece(bool color)
        {
            Color = color;
        } 

        /// <summary>
        /// Return all basic <see cref="Move"/>'s available for <see cref="Piece"/> at
        /// a given <paramref name="position"/>.
        /// </summary>
        /// <param name="position">Dictionary containing <see cref="IPiece"/>'s at
        /// various <see cref="Square"/>'s</param>
        /// <returns></returns>
        public abstract IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position);

        /// <summary>
        /// Gets the <see cref="Square"/> where <see cref="Piece"/> is
        /// placed, based on a given <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A read-only <see cref="IPiece"/> dictionary.</param>
        /// <returns></returns>
        public Square GetSquareFrom(IReadOnlyDictionary<Square,IPiece> position)
        {
            var ls = position
                .Select(p => p.Key)
                .Where(k => position[k] == this)
                .ToList();
            
            if (ls.Count == 0)
                return null;

            return new Square(ls.First());
        }

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