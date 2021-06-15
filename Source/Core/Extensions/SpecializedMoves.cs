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
        /// <see cref="Pawn"/>'s En Passant move.
        /// </summary>
        /// <param name="piece">Must inherit from <see cref="Pawn"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static Move EnPassant(
            this IPiece piece, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries)
        {
            if (piece is not Pawn) return null;

            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="Pawn"/>'s first move is doubled.
        /// </summary>
        /// <param name="piece">Must inherit from <see cref="Pawn"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static Move PawnFirstMove(
            this IPiece piece, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries)
        {
            var square = ((Piece)piece).GetSquareFrom(position);     

            return (
                    piece is Pawn && 
                    !piece.HasMoved(position, moveEntries) &&
                    square.Rank == (piece.Color ? Ranks.two : Ranks.seven) &&
                    !position.TryGetValue(
                        square.Maneuver(
                            Through.Ranks, 
                            piece.Color ? 1 : -1), 
                            out IPiece fp)) 
                ?
                    new []{
                        ((Piece)piece)
                        .AttackSquare(
                            square
                            .Maneuver(
                                Through.Ranks, 
                                piece.Color ? 2 : -2), 
                                position)}
                        .FirstOrDefault(
                            m => m.Type == MoveType.Normal)
                : 
                    null;
        }

    }
}