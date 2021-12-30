using System.Collections.Generic;
using Mate.Core.Elements;

namespace Mate.Core.Abstractions
{
    /// <summary>
    /// <see cref="IGame"/> interface.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// The <see cref="IGame.Outcome"/>. 
        /// </summary>
        Outcome Outcome { get; }

        /// <summary>
        /// The current move count being played on this <see cref="IGame"/> instance,
        /// starting at zero.
        /// </summary>
        /// <value>A game move is a sequence of turns taken by players since the
        /// start of the game.
        /// Differently then what's usual in chess,
        /// it will start at <see langword="0"/>.</value>
        uint MoveCount { get; }

        /// <summary>
        /// The current player to make the next move.
        /// </summary>
        /// <value><see langword="true"/> for player with white pieces. Otherwise, 
        /// player with black pieces.</value>
        bool CurrentPlayer { get; }

        /// <summary>
        /// The current position on the <see cref="Board"/>.
        /// </summary>
        /// <value>A read-only dictionary of <see cref="Square"/>-<see cref="IPiece"/> 
        /// pairs.</value>
        IReadOnlyDictionary<Square, IPiece> Position { get; }

        /// <summary>
        /// A collection of all the move entries in a game o <see cref="Chess"/>.
        /// </summary>
        /// <value>A read-only collection of processed <see cref="MoveEntry"/>
        /// instances.</value>
        IReadOnlyCollection<MoveEntry> MoveEntries { get; }

        /// <summary>
        /// Notational list of moves, occuring at each chess <see cref="IGame.MoveCount"/>. 
        /// </summary>
        IReadOnlyList<IReadOnlyList<Move>> Moves { get; }

        /// <summary>
        /// A collection of captured <see cref="IPiece"/> instances. 
        /// </summary>
        IReadOnlyCollection<IPiece> CapturedPieces { get; }

        /// <summary>
        /// The <see cref="IGame"/> current score, calculated based on the <see cref="CapturedPieces"/>.
        /// </summary> 
        /// <value>Positive values favor the player with the white pieces, while negative
        /// values favor the player with black pieces. Piece value is set by the current
        /// <see cref="IGame"/> class implementation.</value>
        int Score { get; }

        /// <summary>
        /// List of <see cref="Move"/> instances available for <see cref="IGame.CurrentPlayer"/>. 
        /// </summary>
        /// <returns>A read-only collection of <see cref="Move"/> instances.</returns>
        IReadOnlyCollection<Move> AvailableMoves();

        /// <summary>
        /// Process the given <paramref name="move"/>, if it is possible.
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns>True if the move was properly processed. Otherwise, 
        /// False.</returns>
        bool ProcessMove(Move move);
    }
}