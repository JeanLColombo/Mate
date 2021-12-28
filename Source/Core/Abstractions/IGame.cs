namespace Mate.Core.Abstractions
{
    /// <summary>
    /// <see cref="IGame"/> interface.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        ///  The current move being played on this <see cref="IGame"/> instance.
        /// </summary>
        /// <value></value>
        int CurrentMove { get; set; }

        /// <summary>
        /// The current player to make the next move.
        /// </summary>
        /// <value>True for player with white pieces. Otherwise, 
        /// player with black pieces.</value>
        bool CurrentPlayer { get; set; }

        /// <summary>
        /// The rules of <see cref="IChess"/> that are currently being played.
        /// </summary>
        /// <value></value>
        IChess Chess { get; }

        /// <summary>
        /// Process the given <paramref name="move"/>, if it is possible.
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns>True if the move was properly processed. Otherwise, 
        /// False.</returns>
        bool ProcessMove(Move move);
    }
}