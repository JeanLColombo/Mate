using System.Collections.Generic;
using Core.Abstractions;
using Core.Elements;

namespace Core.Extensions
{
    /// <summary>
    /// Provide extension methods for <see cref="Piece"/> attack logic in a
    /// given <see cref="Board.Position"/>.
    /// </summary>
    public static class Attacking
    { 
        /// <summary>
        /// Returns the corresponding <see cref="Move"/> associated with 
        /// <paramref name="piece"/>, attacking a <paramref name="square"/>, based on the
        /// given <paramref name="position"/>.
        /// </summary>
        /// <param name="piece">Attacking <see cref="Piece"/>.</param>
        /// <param name="square">Attacked <see cref="Square"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns>The corresponding <see cref="Move"/> associated with 
        /// this attack.</returns>
        public static Move AttackSquare(
            this Piece piece, 
            Square square, 
            IReadOnlyDictionary<Square, IPiece> position)
        {
            var originSquare = piece.GetSquareFrom(position);

            if(originSquare is null || square is null)
                return null;

            var attackedPiece = position[square];

            if(attackedPiece is null)
                return new Move(originSquare, square, MoveType.Normal);

            if(attackedPiece.Color != piece.Color)
                return new Move(originSquare, square, MoveType.Capture);

            return null; 
        }

    }
}