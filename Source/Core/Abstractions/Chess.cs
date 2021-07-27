using System.Collections.Generic;
using Core.Elements;

namespace Core.Abstractions
{
    /// <summary>
    /// Implements <see cref="Chess"/>, and it's basic rules.
    /// </summary>
    public abstract class Chess : IChess
    {

        /// <summary>
        /// Chessboard, invisible to users.
        /// </summary>
        /// <value></value>
        private Board Board { get; }

        /// <summary>
        /// List of <see cref="MoveEntry"/> objects, invisible to users.
        /// </summary>
        /// <typeparam name="MoveEntry"></typeparam>
        /// <returns></returns>
        private List<MoveEntry> _moveEntries { get; } = new List<MoveEntry>();


        /// <summary>
        /// The current position on the <see cref="Board"/>.
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Square,IPiece> Position {get => Board.Position; }

        /// <summary>
        /// A <see cref="MoveEntry"/> read-only collection of all past 
        /// <see cref="Move"/> instances processed by the <see cref="Chess"/>
        /// game.
        /// </summary>
        /// <typeparam name="MoveEntry"></typeparam>
        /// <returns></returns>
        public IReadOnlyCollection<MoveEntry> MoveEntries {get => _moveEntries; }

        /// <summary>
        /// Creates a new <see cref="Chess"/> object, with no pieces.
        /// </summary>
        public Chess() : this(new Dictionary<Square,IPiece>()) {}

        /// <summary>
        /// Creates a new <see cref="Chess"/> object with a given 
        /// <paramref name="position"/>
        /// </summary>
        /// <param name="position">A given position.</param>
        public Chess(IReadOnlyDictionary<Square, IPiece> position) 
            { Board = new Board(position); }

        /// <summary>
        /// Currently available moves to a player, based on the given 
        /// <paramref name="color"/> of their pieces.
        /// </summary>
        /// <param name="color">True for white, false for black.</param>
        /// <returns>A read-only collection of <see cref="Move"/> objects.</returns>
        public abstract IReadOnlyCollection<Move> AvailableMoves(bool color);

        /// <summary>
        /// Associates <see cref="IChess.Position"/> with <see cref="Position"/>.
        /// </summary>
        IReadOnlyDictionary<Square,IPiece> IChess.Position => Position;

        /// <summary>
        /// Associates <see cref="IChess.MoveEntries"/> with <see cref="MoveEntries"/>.
        /// </summary>
        IReadOnlyCollection<MoveEntry> IChess.MoveEntries => MoveEntries;

        /// <summary>
        /// Associates <see cref="IChess.AvailableMoves"/> with <see cref="AvailableMoves"/>.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        IReadOnlyCollection<Move> IChess.AvailableMoves(bool c) => AvailableMoves(c);
    }
}