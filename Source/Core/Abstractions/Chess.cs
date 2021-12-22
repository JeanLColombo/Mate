using System;
using System.Linq;
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
        /// <returns></returns>
        private List<MoveEntry> _moveEntries { get; } = new List<MoveEntry>();

        /// <summary>
        /// The current position on the <see cref="Board"/>.
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Square, IPiece> Position { get => Board.Position; }

        /// <summary>
        /// A <see cref="MoveEntry"/> read-only collection of all past 
        /// <see cref="Move"/> instances processed by the <see cref="Chess"/>
        /// game.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<MoveEntry> MoveEntries { get => _moveEntries; }

        /// <summary>
        /// Creates a new <see cref="Chess"/> object, with no pieces.
        /// </summary>
        public Chess() : this(new Dictionary<Square, IPiece>()) { }

        /// <summary>
        /// Creates a new <see cref="Chess"/> object with a given 
        /// <paramref name="position"/>
        /// </summary>
        /// <param name="position">A given position.</param>
        public Chess(IReadOnlyDictionary<Square, IPiece> position)
        { Board = new Board(position); }

        /// <summary>
        /// Creates a new instance with given <paramref name="position"/>, containing the
        /// given <paramref name="moveEntries"/>. 
        /// </summary>
        /// <param name="position">A read-only <see cref="IPiece"/> dictionary.</param>
        /// <param name="moveEntries">A read-only collection of <see cref="MoveEntry"/> instances.</param>
        public Chess(
            IReadOnlyDictionary<Square, IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries) 
            : this(position) 
            => _moveEntries = moveEntries.ToList();

        /// <summary>
        /// Places a given <paramref name="piece"/> at a given 
        /// <paramref name="square"/>. 
        /// </summary>
        /// <param name="square">A given <see cref="Square"/>.</param>
        /// <param name="piece">A given <see cref="IPiece"/> instance.</param>
        /// <exception cref="ArgumentException">If the given <paramref name="square"/>
        /// is taken, an exception is thrown.</exception>
        public void PlaceAt(Square square, IPiece piece)
        {
            if (Position.ContainsKey(square))
                throw new ArgumentException(
                    message: "Cannot place a piece at occupied square",
                    paramName: nameof(square));

            Board.Pieces[square] = piece;
        }

        /// <summary>
        /// Clears the given <paramref name="square"/> from its <see cref="IPiece"/>.
        /// </summary>
        /// <param name="square">A given <see cref="Square"/>.</param>
        /// <exception cref="ArgumentException">If the given <paramref name="square"/>
        /// is unoccupied, an exception is thrown.</exception>
        public void Clear(Square square)
        {
            if (!Position.ContainsKey(square))
                throw new ArgumentException(
                    message: "Cannot remove a piece from an unoccupied square",
                    paramName: nameof(square));

            Board.Pieces.Remove(square);
        }

        /// <summary>
        /// Adds a new <paramref name="entry"/> to current game of <see cref="Chess"/>. 
        /// </summary>
        /// <param name="entry">A pre-processed <see cref="MoveEntry"/>.</param>
        /// <returns><see langword="true"/> if the move entry was properly added.</returns>
        public void Add(MoveEntry entry) => _moveEntries.Add(entry);

        /// <summary>
        /// All moves, legal or illegal, currently available to a player, based on
        /// the given <paramref name="color"/> of their pieces.
        /// </summary>
        /// <param name="color"><see langword="true"/> for white, <see langword="false"/> for black.</param>
        /// <returns>A read-only collection of <see cref="Move"/> instances.</returns>
        public abstract IReadOnlyCollection<Move> AllMoves(bool color);

        /// <summary>
        /// Currently available moves to a player, based on the given 
        /// <paramref name="color"/> of their pieces.
        /// </summary>
        /// <param name="color"><see langword="true"/> for white, <see langword="false"/> for black.</param>
        /// <returns>A read-only collection of <see cref="Move"/> instances.</returns>
        public abstract IReadOnlyCollection<Move> AvailableMoves(bool color);

        /// <summary>
        /// Process a given <paramref name="move"/>, if it is available to the player. 
        /// </summary>
        /// <param name="move">A given <see cref="Move"/> instance.</param>
        /// <param name="piece">If the processed <paramref name="move"/> removes a piece
        /// from the game, <see langword="out"/> a reference to it.</param>
        /// <returns><see langword="true"/> if the move is processed properly.
        /// Otherwise, <see langword="false"/>.</returns>
        public abstract bool Process(Move move, out IPiece piece);


        //TODO: Chess.AllMoves, private or public?
        //TODO: Test AvailableMoves


        /// <summary>
        /// Associates <see cref="IChess.Position"/> with <see cref="Position"/>.
        /// </summary>
        IReadOnlyDictionary<Square, IPiece> IChess.Position => Position;

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

        /// <summary>
        /// Associates <see cref="IChess.Process(Move, out IPiece)"/> with <see cref="Process"/>. 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        bool IChess.Process(Move m, out IPiece p)
        {
            // Adds null reference to p
            p = null;

            // List of available moves.
            var available = new bool[] { true, false }
                .SelectMany(c => AvailableMoves(c)).ToList();

            // If move is not available, return false
            if (!available.Contains(m))
                return false;

            // Adds current move and position to historical entries
            Add(new MoveEntry(m, Position));

            // Call move processing overload
            return Process(m, out p);
        }

    }
}
