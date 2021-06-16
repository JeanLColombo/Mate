using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Elements.Pieces;

namespace Core.Extensions.SpecializedMoves
{
    /// <summary>
    /// Provides extension methods for special <see cref="Pawn"/>'s
    /// En Passant logic.
    /// </summary>
    public static class PawnPassant
    {   
        /// <summary>
        /// <see cref="Pawn"/>'s En Passant move.
        /// </summary>
        /// <param name="piece">Must inherit from <see cref="Pawn"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static IReadOnlyCollection<Move> EnPassant(
            this IPiece piece, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries)
        {
            var move = new HashSet<Move>();

            if (piece is not Pawn || moveEntries.Count == 0) return move;

            var lastMove = moveEntries.Last().Move;

            if (position[lastMove.ToSquare] is not Pawn) return move;

            var square = ((Piece)piece).GetSquareFrom(position);

            if (
                square is null || 
                square.Rank != (piece.Color ? Ranks.five : Ranks.four)) 
                return move;

            var adjacentSquares = new []{1, -1}.Select(nr => square.Maneuver(Through.Files, nr)).ToList();

            if (
                !(adjacentSquares.Contains(lastMove.ToSquare)) || 
                lastMove.FromSquare.Rank != (piece.Color ? Ranks.seven : Ranks.two))
                return move;

            move.Add(new Move(
                new Square(square), 
                new Square(
                    lastMove.ToSquare.File, 
                    (Ranks)((int)lastMove.ToSquare.Rank + (piece.Color ? 1 : -1))), 
                MoveType.Passant));

            return move;
        }    

    }
}