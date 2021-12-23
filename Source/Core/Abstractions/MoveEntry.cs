using System.Collections.Generic;
using Core.Elements;

namespace Core.Abstractions
{
    /// <summary>
    /// Records a <see cref="Move"/> entry applied to a <see cref="Board"/> state. 
    /// </summary>
    public class MoveEntry
    {
        /// <summary>
        /// The recorded <see cref="Move"/> entry.
        /// </summary>
        /// <value></value>    
        public Move Move { get; }     

        /// <summary>
        /// The recorded <see cref="Board.Position"/>.
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Square, IPiece> Position {get => board.Position; }

        /// <summary>
        /// The recorded <see cref="Board"/>.
        /// </summary>
        /// <value></value>
        private Board board { get; }   

        /// <summary>
        /// Creates a new <paramref name="move"/> entry applied to 
        /// a given <paramref name="position"/>.
        /// </summary>
        /// <param name="move">A <see cref="Move"/> applied to 
        /// <paramref name="position"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public MoveEntry(Move move, IReadOnlyDictionary<Square, IPiece> position)
        { 
            Move = move;
            board = new Board(position);
        }

        /// <summary>
        /// Generates a new instance from a given <paramref name="move"/>
        /// and a given <paramref name="board"/>, based on <see cref="Board.Position"/>. 
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <param name="board">A given <see cref="Board"/>.</param>
        public MoveEntry(Move move, Board board) : this(move, board.Position) {}
    }
}