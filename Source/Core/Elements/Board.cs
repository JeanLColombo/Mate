using System.Collections.Generic;
using Core.Abstractions;

namespace Core.Elements
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
        /// <typeparam name="Square">Used as a <c>Key</c> 
        /// to access pieces.</typeparam>
        /// <typeparam name="IPiece">The piece on the <c>Square</c>. 
        /// Can be <c>null</c>.</typeparam>
        /// <returns></returns>
        internal Dictionary<Square,IPiece> Pieces {get; set;} = new  Dictionary<Square,IPiece>();

        /// <summary>
        /// Creates a new <see cref="Board"/> object with no <see cref="IPiece"/>'s.
        /// </summary>
        /// <returns></returns>
        public Board() {}
    }
}