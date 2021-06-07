using System;
using System.Collections.Generic;
using Core.Elements;

namespace Core.Abstractions
{
    /// <summary>
    /// Records a <see cref="Move"/> entry applied to a <see cref="Board"/> state. 
    /// </summary>
    public class MoveEntry : Tuple<Move, Board>
    {
        /// <summary>
        /// The recorded <see cref="Move"/> entry.
        /// </summary>
        /// <value></value>    
        public Move Move { get => Item1; }     

        /// <summary>
        /// The recorded <see cref="Board.Position"/>.
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Square, IPiece> Position {get => Item2.Position; }

        /// <summary>
        /// Creates a new <paramref name="move"/> entry applied to 
        /// a given <paramref name="position"/>.
        /// </summary>
        /// <param name="move">A <see cref="Move"/> applied to 
        /// <paramref name="position"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public MoveEntry(Move move, IReadOnlyDictionary<Square, IPiece> position) : 
            base(move, new Board(position)) { }

        /// <summary>
        /// Creates a new <paramref name="move"/> entry applied to 
        /// a given <paramref name="board"/>.
        /// </summary>
        /// <param name="move">A <see cref="Move"/> applied to 
        /// <paramref name="position"/>.</param>
        /// <param name="board">A given <see cref="Board"/>.</param>
        /// <returns></returns>
        public MoveEntry(Move move, Board board) : this(move, board.Position) {}
    }
}