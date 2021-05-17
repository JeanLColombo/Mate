using System;
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

            if(!(position.TryGetValue(square, out var attackedPiece)))
                return new Move(originSquare, square, MoveType.Normal);

            if(attackedPiece.Color != piece.Color)
                return new Move(originSquare, square, MoveType.Capture);

            return null; 
        }

        /// <summary>
        /// Attack all squares through a certain direction.
        /// </summary>
        /// <param name="piece">Attacking <see cref="Piece"/>.</param>
        /// <param name="orientation">Attack orientation.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="sense">True if the attack sense follows the orientation.
        /// False otherwise.</param>
        /// <returns>A read-only <see cref="Move"/> collection.</returns>
        public static IReadOnlyCollection<Move> Attack(
            this Piece piece, 
            Through orientation, 
            bool sense,
            IReadOnlyDictionary<Square, IPiece> position)
        {
            throw new NotImplementedException();
        }

    }
}