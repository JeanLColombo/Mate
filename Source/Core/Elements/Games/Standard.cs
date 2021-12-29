using Mate.Core.Abstractions;

namespace Mate.Core.Elements.Games
{
    /// <summary>
    /// Implements a standard, two players, <see cref="Game"/>, following the
    /// given <see cref="IChess"/> rules. 
    /// </summary>
    public class Standard : Game
    {
        /// <summary>
        /// Creates a new <see cref="Standard"/> <see cref="Game"/> instance,
        /// to be played according to the given <paramref name="chess"/> rules.
        /// <list type="bullet">
        ///     <listheader>
        ///         <term><see cref="Standard"/> <see cref="Game"/></term>
        ///         <description>Rules:</description>
        ///     </listheader>
        ///     <item>
        ///         <description>Player with white pieces starts first.</description>
        ///     </item>
        ///     <item>
        ///         <description>Each move is a composition of a <see cref="Move"/>
        ///         done by each player.</description>
        ///     </item>
        ///     <item>
        ///         <description>After each move, the <see cref="Game.Move"/> counter
        ///         is increased by one.</description>
        ///     </item>
        ///     <item>
        ///         <description>The game ends when there are no available moves
        ///         for a given player.</description>
        ///     </item>
        ///     <item>
        ///         <description>The game is a <see cref="Outcome.Stalemate"/> if
        ///         the player with no moves is not checked.</description>
        ///     </item>
        ///     <item>
        ///         <description>The game is a <see cref="Outcome.Checkmate"/> if
        ///         the player with no moves is checked. In this case, the other
        ///         player wins.</description>
        ///     </item>
        ///     <item>
        ///         <description><see cref="IPiece"/> setup and maneuverability rules
        ///         are set by the given <paramref name="chess"/> instance.</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="chess">The given <paramref name="chess"/> instance. It must have
        /// a copy construct.</param>
        public Standard(IChess chess) : base(0, true, chess) {}

        //TODO: find a way to implement templated constructors.
    }
}