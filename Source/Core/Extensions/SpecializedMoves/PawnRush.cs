using System.Collections.Generic;
using System.Linq;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Pieces;

namespace Mate.Core.Extensions.SpecializedMoves
{
    /// <summary>
    /// Provides extension methods for <see cref="Pawn"/> first move.
    /// </summary>
    public static class PawnRush
    {
       /// <summary>
        /// <see cref="Pawn"/>'s first move is doubled.
        /// </summary>
        /// <param name="piece">Must inherit from <see cref="Pawn"/>.</param>
        /// <param name="position">A given <see cref="Core.Elements.Board.Position"/>.</param>
        /// <returns></returns>
        public static IReadOnlyCollection<Move> PawnFirstMove(
            this IPiece piece, 
            IReadOnlyDictionary<Square,IPiece> position)
        {
            var square = ((Piece)piece).GetSquareFrom(position);     

            var move = new HashSet<Move>();

            move.AddNonNull((
                    piece is Pawn && 
                    square is not null &&
                    square.Rank == (piece.Color ? Ranks.two : Ranks.seven) &&
                    !position.TryGetValue(
                        square.Maneuver(
                            Through.Ranks, 
                            piece.Color ? 1 : -1), 
                            out IPiece fp)) 
                ?
                    ((Piece)piece)
                            .AttackSquare(
                                square
                                .Maneuver(
                                    Through.Ranks, 
                                    piece.Color ? 2 : -2), 
                                    position)
                : 
                    null);

            return move
                .Where(m => m.Type == MoveType.Normal)
                .Select(m => new Move(m.FromSquare, m.ToSquare, MoveType.Rush))
                .ToList();
        }
    }
}