namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Interfaces an <see cref="IPlayer"/> in an <see cref="IMatch"/> of <see cref="IChess"/>. 
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// In a given <paramref name="match"/>, resigns the the <see cref="IMatch.CurrentGame"/>.  
        /// </summary>
        /// <param name="match">A given <see cref="IMatch"/> in witch this <see cref="IPlayer"/>
        /// is taking part of.</param>
        /// <returns>The <see cref="IMatch.CurrentGame.Outcome"/>.</returns>
        Outcome Resign(IMatch match);

        /// <summary>
        /// Offers (or accepts) a draw in the <see cref="IMatch.CurrentGame"/> being played in a
        /// given <paramref name="match"/>.
        /// </summary>
        /// <param name="match">A given <see cref="IMatch"/> in witch this <see cref="IPlayer"/>
        /// is taking part of.</param>
        /// <returns>The <see cref="IMatch.CurrentGame.Outcome"/>.</returns>
        Outcome Draw(IMatch match);

        /// <summary>
        /// Plays the current given <paramref name="move"/> in the <see cref="IMatch.CurrentGame"/> 
        /// being played in a given <paramref name="match"/>. 
        /// </summary>
        /// <param name="match">A given <see cref="IMatch"/> in witch this <see cref="IPlayer"/>
        /// is taking part of.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns><see langword="true"/> if the <paramref name="move"/> is properly processed.
        /// Otherwise, returns false.</returns>
        bool Play(IMatch match, Move move);
    }
}