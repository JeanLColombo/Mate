using System;
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
        public Board() => BuildBoard();

        /// <summary>
        /// Build a <see cref="Board"/>, based on <see cref="Files"/> and <see cref="Ranks"/>,
        /// with no <see cref="IPiece"/>'s.
        /// </summary>
        private void BuildBoard()
        {
            //TODO: The problem lies here. Board already can have a Pieces dictionary that is empty. We will start here.
            foreach (Files f in Enum.GetValues(typeof(Files)))
                foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
                    Pieces.Add(new Square(f, r), null);
        }
    }
}