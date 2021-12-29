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
        /// <summary>
        /// Creates the <see cref="Classical"/> <see cref="Chess.Position"/>.
        /// </summary>
        /// <returns>A read-only dictionary of 
        /// <see cref="Square"/>-<see cref="IPiece"/> pairs.</returns>
        private static IReadOnlyDictionary<Square, IPiece> StandardPosition
            => new Ranks[] { Ranks.one, Ranks.two, Ranks.seven, Ranks.eight }
                .SelectMany(r =>
                    Enum
                    .GetValues(typeof(Files))
                    .Cast<Files>()
                    .Select(f => new Square(f, r)))
                .Select(s =>
                {
                    bool color = s.Rank == Ranks.one || s.Rank == Ranks.two;
                    bool pawn = s.Rank == Ranks.two || s.Rank == Ranks.seven;

                    IPiece piece = null;

                    if (pawn)
                    {
                        piece = new Pawn(color);
                        return (s, piece);
                    }

                    switch (s.File)
                    {
                        case Files.a:
                        case Files.h:
                            piece = new Rook(color);
                            break;
                        case Files.b:
                        case Files.g:
                            piece = new Knight(color);
                            break;
                        case Files.c:
                        case Files.f:
                            piece = new Bishop(color);
                            break;
                        case Files.d:
                            piece = new Queen(color);
                            break;
                        case Files.e:
                            piece = new King(color);
                            break;
                    }

                    return (s, piece);
                })
                .ToDictionary(sp => sp.s, sp => sp.piece);

        /// <summary>
        /// Creates a new <see cref="Classical"/> set of chess rules. 
        /// </summary>
        public Classical() : base(StandardPosition) {}
    }
}