using System.Collections.Generic;

namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Abstract implementation of a game of <see cref="Chess"/>.
    /// </summary>
    public abstract class Game : IGame
    {
        /// <summary>
        /// The current move being played in the <see cref="Game"/>.
        /// </summary>
        /// <value>A game move is a sequence of turns taken by players since the
        /// start of the game.
        /// Differently then what's usual in chess,
        /// it Will start at <see langword="0"/>.</value>
        public uint Move { get; protected set; }

        /// <summary>
        /// The current player to make a move.
        /// </summary>
        /// <value><see langword="true"/> for player with white pieces, 
        /// <see langword="false"/> for player with black pieces.</value>
        public bool CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current <see cref="IChess"/> rules of the game.
        /// </summary>
        internal IChess Chess { get; }

        /// <summary>
        /// The notational list of moves played each move. 
        /// </summary>
        internal List<List<Move>> _moves { get; } = new List<List<Move>>();

        /// <summary>
        /// A list of captured <see cref="IPiece"/> instances. 
        /// </summary>
        internal List<IPiece> _captured { get; } = new List<IPiece>();

        /// <summary>
        /// Creates a new <see cref="Game"/> instance. 
        /// </summary>
        /// <param name="currentMove">Sets the <see cref="Game.Move"/>, 
        /// starting at <see langword="0"/>.</param>
        /// <param name="currentPlayer">Sets the <see cref="Game.CurrentPlayer"/>.</param>
        /// <param name="rules">A given <see cref="IChess"/> instance.</param>
        public Game(uint currentMove, bool currentPlayer, IChess rules)
        {
            Move = currentMove;
            CurrentPlayer = currentPlayer;
            Chess = rules;
        }

        /// <summary>
        /// Process a given <paramref name="move"/>, depending on the
        /// <see cref="Game.Chess"/> rules, as well as the 
        /// <see cref="Game.CurrentPlayer"/>.
        /// </summary>
        /// <param name="move">A legal <see cref="Move"/> currently available
        /// to <see cref="Game.CurrentPlayer"/>.</param>
        /// <returns><see langword="true"/> if move was properly processed. 
        /// Otherwise, <see langword="false"/>.</returns>
        public abstract bool ProcessMove(Move move);

        uint IGame.Move => Move;

        bool IGame.CurrentPlayer => CurrentPlayer;

        IReadOnlyDictionary<Square, IPiece> IGame.Position => Chess.Position;

        IReadOnlyCollection<MoveEntry> IGame.MoveEntries => Chess.MoveEntries;

        IReadOnlyList<IReadOnlyList<Move>> IGame.Moves => _moves;

        IReadOnlyCollection<IPiece> IGame.CapturedPieces => _captured;

        bool IGame.ProcessMove(Move m) => ProcessMove(m);

        IReadOnlyCollection<Move> IGame.AvailableMoves() => Chess.AvailableMoves(CurrentPlayer);
    }
}