using System.Collections.Generic;
namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Defines an abstract <see cref="Match"/> between two players, taking their inputs and managing <see cref="IGame"/> 
    /// instances and their outcome. 
    /// </summary>
    public abstract class Match : IMatch
    {
        IReadOnlyList<IGame> IMatch.PlayedGames { get; }

        IReadOnlyList<IPlayer> IMatch.Players { get; }

        IGame IMatch.CurrentGame { get; }

        int IMatch.MaximumNumberOfGames { get; }

        int IMatch.TotalGamesFinished { get; }

        bool IMatch.MatchIsOver { get; }
    }
}