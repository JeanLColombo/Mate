using System;
using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;

namespace Core.Extensions.SpecializedMoves
{
    /// <summary>
    /// Provides extension methods for castling, both king and queen side.
    /// </summary>
    public static class Castling
    {
        /// <summary>
        /// Return available castling options for <paramref name="king"/>, given
        /// a <paramref name="position"/> and <paramref name="moveEntries"/>.
        /// </summary>
        /// <param name="king">Must be <see cref="King"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static IReadOnlyCollection<Move> Castles(
            this IPiece king, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries)
        {
            var kingSquare = ((Piece)king).GetSquareFrom(position);    

            if (
                king is not King || 
                kingSquare is null  ||
                kingSquare.Rank != (king.Color ? Ranks.one : Ranks.eight) ||
                king.HasMoved(position, moveEntries)) 
                return Enumerable.Empty<Move>().ToList();

            var rookSquares = position
                .Where(kv => kv.Value.Color == king.Color && kv.Value is Rook)
                .Where(kv => !kv.Value.HasMoved(position, moveEntries))
                .Where(kv => kv.Key.IsSameRankAs(kingSquare))
                .Select(kv => kv.Key)
                .ToList();    

            return rookSquares
                .Where(
                    rs => kingSquare
                        .InBetweenSquares(rs)
                        .All(s => !position.TryGetValue(s, out IPiece piece)))
                .Select(rs =>                    
                    (rs.File < kingSquare.File) ? 
                        new Move(
                            new Square(kingSquare),
                            new Square(Files.c, kingSquare.Rank),
                            MoveType.Castle) :
                        new Move(
                            new Square(kingSquare),
                            new Square(Files.g, kingSquare.Rank),
                            MoveType.Castle))
                .ToList();
        }
    }
}