using System;
using System.Collections.Generic;
using Core.Abstractions;

namespace Core.Elements
{
    /// <summary>
    /// Defines a chess <c>Board</c> and its properties.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Get the current position on the <c>Board</c>.
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Square, IPiece> Position { get => Pieces; }

        /// <summary>
        /// The Dictionary of Pieces on the board, based on their
        /// position.
        /// </summary>
        /// <typeparam name="Square">Used as a <c>Key</c> 
        /// to access pieces.</typeparam>
        /// <typeparam name="IPiece">The piece on the <c>Square</c>. 
        /// Can be <c>null</c>.</typeparam>
        /// <returns></returns>
        private Dictionary<Square,IPiece> Pieces {get; set;} = new  Dictionary<Square,IPiece>();

        /// <summary>
        /// Creates a new <c>Board</c> object with no Pieces.
        /// </summary>
        /// <returns></returns>
        public Board() => BuildBoard();

        /// <summary>
        /// Build a <c>Board</c> based on <c>Files</c> and <c>Ranks</c>
        /// with no Pieces.
        /// </summary>
        private void BuildBoard()
        {
            foreach (Files f in Enum.GetValues(typeof(Files)))
                foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
                    Pieces.Add(new Square(f, r), null);
        }
    }
}