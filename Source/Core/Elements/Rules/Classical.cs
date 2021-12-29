using System;
using System.Collections.Generic;
using System.Linq;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Pieces;

namespace Mate.Core.Elements.Rules
{
    /// <summary>
    /// Implements the <see cref="Classical"/> set of chess rules. 
    /// </summary>
    public class Classical : Custom
    {
        public Classical() : base()

        public IReadOnlyDictionay<Square, IPiece> StandardPosition =>
            new Ranks[]{Ranks.one, Ranks.two, Ranks.seven, Ranks.eight}
                .SelectMany(r => 
                    Enum
                    .GetValues(typeof(Files))
                    .Cast<Files>()
                    .Select(f => new Square(f, r)))
                .Select(s => {
                    bool color = s.Rank == Ranks.one || s.Rank == Ranks.two;
                    bool pawn = s.Rank == Ranks.two || s.Rank == Ranks.seven;

                    if (pawn)
                        return new KeyValuePair(new Square(s), new Pawn(color));
                    //TODO: Finish and test Classical chess.
                })
    }
}