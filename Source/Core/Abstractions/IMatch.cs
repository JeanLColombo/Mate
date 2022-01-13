using System.Collections.Generic;

namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Interfaces a match between two players, taking their inputs and managing <see cref="IGame"/> 
    /// instances and their outcome. 
    /// </summary>
    public interface IMatch
    {

        /// <summary>
        /// A list of games already played in this <see cref="IMatch"/>. 
        /// </summary>
        IReadOnlyList<IGame> PlayedGames { get; }

        /// <summary>
        /// A list of <see cref="IPlayer"/> instances taking place in this match. 
        /// </summary>
        IReadOnlyList<IPlayer> Players { get; }

        /// <summary>
        /// The current <see cref="IGame"/> being played. 
        /// </summary>
        IGame CurrentGame { get; }

        /// <summary>
        /// The maximum number of <see cref="IGame"/> instances to be played in this 
        /// <see cref="IMatch"/>. 
        /// </summary>
        int MaximumNumberOfGames { get; }

        /// <summary>
        /// The total number of finished <see cref="IGame"/> instances already
        /// played.
        /// </summary>
        int TotalGamesFinished { get; }

        /// <summary>
        /// Defines wether the <see cref="IMatch"/> is over. 
        /// </summary>
        bool MatchIsOver { get; }
    }
}