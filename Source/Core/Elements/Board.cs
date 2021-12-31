using System.Collections.Generic;
using Mate.Core.Abstractions;
using Mate.Core.Extensions;

namespace Mate.Core.Elements
{
    /// <summary>
    /// Defines a chess <see cref="Board"/> and its properties.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Get the current position on the <see cref="Board"/>.
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Square, IPiece> Position { get => Pieces; }

        /// <summary>
        /// The Dictionary of <see cref="IPiece"/>'s on the board, based on their
        /// <see cref="Square"/>.
        /// </summary>
        /// <returns></returns>
        internal Dictionary<Square,IPiece> Pieces {get; set;} = new  Dictionary<Square,IPiece>();

        /// <summary>
        /// Creates a new <see cref="Board"/> object with no <see cref="IPiece"/>'s.
        /// </summary>
        /// <returns></returns>
        public Board() {}

        /// <summary>
        /// Creates a new instance of <see cref="Board"/>, containing a complete 
        /// copy of given <paramref name="position"/>.
        /// </summary>
        /// <param name="position">A read-only dictionary of <see cref="IPiece"/> instances
        /// placed in <see cref="Square"/> instances.</param>    
        public Board(IReadOnlyDictionary<Square,IPiece> position) 
        {this.Copy(position);}
    }
}