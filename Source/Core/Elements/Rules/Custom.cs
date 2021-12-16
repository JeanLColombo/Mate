using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Core.Elements.Rules
{
    /// <summary>
    /// Defines a fully customizable game of chess. Special moves can be enabled and / or disabled and 
    /// pieces can be set to any given configuration. 
    /// 
    /// Configuration are passed through via constructor.
    /// </summary>
    public class Custom : Chess
    {

        /// <summary>
        /// List of banned moves. Instanced on construction. <see cref="Core.Abstractions.MoveType"/>'s on this list are not allowed.  
        /// </summary>
        public readonly IEnumerable<MoveType> BannedMoves;

        /// <summary>
        /// Instantiate a new <see cref="Custom"/> game of chess with the give <see paramrefname="position"/> on the board. 
        /// </summary>
        /// <param name="position">A read-only dictionary of pieces.</param>
        public Custom(IReadOnlyDictionary<Square, IPiece> position) : this(
            position, 
            new HashSet<MoveType>(Enumerable.Empty<MoveType>())) {}

        /// <summary>
        /// Instantiate a new <see cref="Custom"/> game of chess with the give <see paramrefname="position"/> on the board,
        /// as well as a given list of banned <see paramrefname="bannedMoves"/> entries.
        /// </summary>
        /// <param name="position">A read-only dictionary of pieces.</param>
        /// <param name="bannedMoves">A list of banned <see cref="Core.Abstractions.MoveType"/> entries.</param>
        public Custom(
            IReadOnlyDictionary<Square, IPiece> position, 
            HashSet<MoveType> bannedMoves) 
            : base(position)
        {
            BannedMoves = bannedMoves;
        }

        /// <summary>
        /// Currently available moves for player with pieces of the given <see paramrefname="color"/>, based on the
        /// list of banned moves.
        /// </summary>
        /// <param name="color"><see langword="true"/> for white, <see langword="false for black"/> for black.</param>
        /// <returns>A read-only collection of <see cref="Move"/> instances.</returns>
        /// <exception cref="System.NotImplementedException">This method is not yet implemented.</exception>
        public override IReadOnlyCollection<Move> AvailableMoves(bool color)
        {
            throw new System.NotImplementedException();
        }
    }
}