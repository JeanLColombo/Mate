namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Defines an abstract <see cref="Player"/> in a <see cref="IMatch"/> of <see cref="IChess"/>. 
    /// </summary>
    public abstract class Player : IPlayer
    {
        /// <summary>
        /// Sets the <paramref name="match"/> <see cref="Outcome"/> to <see cref="Outcome.Resigned"/>.
        /// </summary>
        /// <param name="match">A given <see cref="IMatch"/>.</param>
        /// <returns>The current game <see cref="Outcome"/>.</returns>
        public abstract Outcome Resign(IMatch match);

        /// <summary>
        /// Sets the <paramref name="match"/> <see cref="Outcome"/> to <see cref="Outcome.Drawn"/>.
        /// </summary>
        /// <param name="match">A given <see cref="IMatch"/>.</param>
        /// <returns>The current game <see cref="Outcome"/>.</returns>
        public abstract Outcome Draw(IMatch match);

        /// <summary>
        /// Process the given <paramref name="move"/> in the <see cref="IMatch.CurrentGame"/> of the
        /// given <paramref name="match"/>. 
        /// </summary>
        /// <param name="match">A given <see cref="IMatch"/>.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns><see langword="true"/> if the <paramref name="move"/> is properly processed.
        /// Otherwise, returns false.</returns>
        public abstract bool Play(IMatch match, Move move);

        Outcome IPlayer.Resign(IMatch match) => Resign(match);

        Outcome IPlayer.Draw(IMatch match) => Draw(match);

        bool IPlayer.Play(IMatch match, Move move) => Play(match, move);
    }
}