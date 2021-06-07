using System;
using System.Collections.Generic;
using Core.Elements;

namespace Core.Abstractions
{
    /// <summary>
    /// Records a <see cref="Move"/> applied to a <see cref="Board"/> state. 
    /// </summary>
    public class Record : Tuple<Move, Board>
    {
        /// <summary>
        /// The recorded <see cref="Move"/>.
        /// </summary>
        /// <value></value>    
        public Move Move { get => Item1; }     

        /// <summary>
        /// The recorded <see cref="Board.Position"/>.
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Square, IPiece> Position {get => Item2.Position; }

        /// <summary>
        /// Creates a new <paramref name="move"/> record applied to 
        /// a given <paramref name="position"/>.
        /// </summary>
        /// <param name="move">A <see cref="Move"/> applied to 
        /// <paramref name="position"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public Record(Move move, IReadOnlyDictionary<Square, IPiece> position) : 
            base(move, new Board(position)) { }
    }
}