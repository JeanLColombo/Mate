using System.Collections.Generic;
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
        public readonly IReadOnlySet<MoveType> BannedMoves;

        public override IReadOnlyCollection<Move> AvailableMoves(bool color)
        {
            throw new System.NotImplementedException();
        }
    }
}