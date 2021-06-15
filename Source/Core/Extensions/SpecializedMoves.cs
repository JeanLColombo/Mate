using System;
using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Elements.Pieces;

namespace Core.Extensions
{
    /// <summary>
    /// Provides extension methods for special <see cref="Move"/> instances 
    /// that requires additional information, such as en passant, and castles 
    /// </summary>
    public static class SpecializedMoves
    {     
        /// <summary>
        /// Checks if <paramref name="piece" /> has moved.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static bool HasMoved(
            this IPiece piece, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries) 
        {
            var s = ((Piece)piece).GetSquareFrom(position);
            
            return !((moveEntries.Count == 0) || (s is null) || (moveEntries.Select(me => me.Move).FirstOrDefault(m => m.ToSquare.IsSameSquareAs(s)) is null));
        }

        /// <summary>
        /// <see cref="Pawn"/>'s first move is doubled.
        /// </summary>
        /// <param name="piece">Must inherit from <see cref="Pawn"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
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

            return move.Where(m => m.Type == MoveType.Normal).ToList();
        }

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