using System.Collections.Generic;
using System.Linq;
using Mate.Core.Abstractions;
using Mate.Core.Extensions;

namespace Mate.Core.Elements.Games
{
    /// <summary>
    /// Implements a standard, two players, <see cref="Game"/>, following the
    /// given <typeparamref name="TChess"/> rules. 
    /// </summary>
    /// <typeparam name="TChess">A given <see cref="Chess"/> rules implementation.
    /// It must have a parameterless constructor.</typeparam>
    public class Standard<TChess> : Game where TChess : Chess, new()
    {
        /// <summary>
        /// Creates a new <see cref="Standard{TChess}"/> <see cref="Game"/> instance,
        /// to be played according to the given <typeparamref name="TChess"/> rules.
        /// <list type="bullet">
        ///     <listheader>
        ///         <term><see cref="Standard{TChess}"/> <see cref="Game"/></term>
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
        ///         <description>After each move, the <see cref="Game.MoveCount"/> counter
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
        ///         are set by the given <typeparamref name="TChess"/> instance.</description>
        ///     </item>
        /// </list>
        /// </summary>
        public Standard() : base(0, true, new TChess()) {}

        /// <summary>
        /// Process a given <paramref name="move"/>, according to the 
        /// <see cref="Game.CurrentPlayer"/>, the given <typeparamref name="TChess"/>. 
        /// </summary>
        /// <param name="move">A legal <see cref="Move"/>.</param>
        /// <returns><see langword="true"/> if the <paramref name="move"/> was
        /// processed. Otherwise, return <see langword="false"/>.</returns>
        /// <exception cref="KeyNotFoundException">
        /// Performing a <paramref name="move"/> where <see cref="Move.FromSquare"/>
        /// is empty yields an exception.</exception>
        public override bool ProcessMove(Move move)
        {
            // Check if player is moving a piece that matches
            // his own set...
            if (Chess.Position[move.FromSquare].Color != CurrentPlayer)
                return false;

            // ... and if the move is being processed correctly
            if (!Chess.Process(move, out IPiece captured))
                return false;

            // Update game._moves
            if (CurrentPlayer) 
                _moves.Add(Enumerable.Empty<Move>().ToList());

            _moves.Last().Add(move);

            // Update_ the MoveCount 
            MoveCount = _moves.Count;

            // Update the captured pieces
            if(!(captured is null)) 
                _captured.Add(captured);

            // Pass the turn to the other player
            CurrentPlayer = !CurrentPlayer;
            
            // Update the outcome according to the next 
            // players condition...
            
            // ... if under check...
            if (Chess.IsChecked<TChess>(CurrentPlayer))
                Outcome = Outcome.Checked;
            else
                Outcome = Outcome.Game;

            // ... or if there are any moves available 
            if (Chess.AvailableMoves(CurrentPlayer).Count == 0)
            {
                if (Outcome == Outcome.Checked)
                    Outcome = Outcome.Checkmate;
                else
                    Outcome = Outcome.Stalemate;
            }

            // Update complete... return true
            return true;
        }
    }
}