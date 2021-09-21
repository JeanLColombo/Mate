using System.Collections.Generic;
using Core.Abstractions;

namespace Elements.Rules
{
    public class Custom : Chess
    {
        public readonly bool passant;
        public readonly bool castles;

        public override IReadOnlyCollection<Move> AvailableMoves(bool color)
        {
            throw new System.NotImplementedException();
        }
    }
}