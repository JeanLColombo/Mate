using System;
using System.Collections.Generic;
using System.Linq;
using Mate.Core.Elements.Pieces;

namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Abstract implementation of a game of <see cref="Chess"/>.
    /// </summary>
    public abstract class Game : IGame
    {
        /// <summary>
        /// The <see cref="Game.Outcome"/>. 
        /// </summary>
        internal Outcome Outcome { get; set; } = Outcome.Game;

        /// <summary>
        /// The current move being played in the <see cref="Game"/>.
        /// </summary>
        /// <value>A game move is a sequence of turns taken by players since the
        /// start of the game.
        /// Differently then what's usual in chess,
        /// it will start at <see langword="0"/>.</value>
        public int MoveCount { get; protected set; }

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
        /// <param name="currentMove">Sets the <see cref="Game.MoveCount"/>, 
        /// starting at <see langword="0"/>.</param>
        /// <param name="currentPlayer">Sets the <see cref="Game.CurrentPlayer"/>.</param>
        /// <param name="rules">A given <see cref="IChess"/> instance.</param>
        /// <exception cref="ArgumentOutOfRangeException">If 
        /// <paramref name="currentMove"/> is negative.</exception>
        public Game(int currentMove, bool currentPlayer, IChess rules)
        {
            if (currentMove < 0) 
                throw new ArgumentOutOfRangeException(
                    message: "Cannot have a negative currentMove",
                    paramName: nameof(currentMove));

            MoveCount = currentMove;
            CurrentPlayer = currentPlayer;
            Chess = rules;
        }

        /// <summary>
        /// Calculates the current score, based on the <see cref="_captured"/> pieces. 
        /// Calculation is based on the <see cref="IPiece"/> implementation, as well 
        /// as <see cref="IPiece.Color"/>. 
        /// <list type="bullet">
        ///     <listheader>
        ///         <term><see cref="Game"/> <see langword="virtual"/> implementation</term>
        ///         <description>The following implementation considers this
        ///         scoring per <see cref="IPiece"/> implementation.</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Pawn"/></term>
        ///         <description>1 point.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="Bishop"/> or <see cref="Knight"/></term>
        ///         <description>3 points.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="Rook"/></term>
        ///         <description>5 points.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="Queen"/></term>
        ///         <description>9 points.</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <value>Based on current <see cref="Game"/> implementation.</value>
        internal virtual int GetScore() =>
            _captured.Select(p =>
            {
                int value = 0;
                switch(p)
                {
                    case Pawn:
                        value = 1;
                        break;
                    case Knight:
                    case Bishop:
                        value = 3;
                        break;
                    case Rook:
                        value = 5;
                        break;
                    case Queen:
                        value = 9;
                        break;
                }
                return p.Color ? -value : +value;
            }).Sum();

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

        Outcome IGame.Outcome => Outcome;

        int IGame.MoveCount => MoveCount;

        bool IGame.CurrentPlayer => CurrentPlayer;

        IReadOnlyDictionary<Square, IPiece> IGame.Position => Chess.Position;

        IReadOnlyCollection<MoveEntry> IGame.MoveEntries => Chess.MoveEntries;

        IReadOnlyList<IReadOnlyList<Move>> IGame.Moves => _moves;

        IReadOnlyCollection<IPiece> IGame.CapturedPieces => _captured;

        int IGame.Score => GetScore();

        bool IGame.ProcessMove(Move m) => ProcessMove(m);

        IReadOnlyCollection<Move> IGame.AvailableMoves() => Chess.AvailableMoves(CurrentPlayer);
    }
}