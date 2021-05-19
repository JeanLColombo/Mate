using System.Collections.Generic;
using System.Linq;
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

            if(originSquare is null) return null;

            return originSquare.AttackSquare(square, position);   
        }
        

        /// <summary>
        /// Attack all squares through a certain direction.
        /// </summary>
        /// <param name="piece">Attacking <see cref="Piece"/>.</param>
        /// <param name="orientation">Attack orientation.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <param name="sense">True if the attack sense follows the orientation.
        /// False otherwise.</param>
        /// <param name="range">The range of the attack. Indicates how deep the attack is
        /// relative to <see cref="Piece.GetSquareFrom(IReadOnlyDictionary{Square, IPiece})"/>.</param>
        /// <returns>A read-only <see cref="Move"/> collection.</returns>
        public static IReadOnlyCollection<Move> Attack(
            this Piece piece, 
            Through orientation, 
            bool sense,
            IReadOnlyDictionary<Square, IPiece> position,
            int range = 7)
        {
            var originSquare = piece.GetSquareFrom(position);

            if(originSquare is null) return new List<Move>();

            return originSquare.Attack(orientation, sense, position).Take(range).ToList();
        }

        /// <summary>
        /// Internal logic for <see cref="AttackSquare"/>.
        /// </summary>
        /// <param name="originSquare">Attacker square, based on 
        /// <paramref name="position"/>.</param>
        /// <param name="square">Attacked <see cref="Square"/>.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        private static Move AttackSquare(
            this Square originSquare,
            Square square, 
            IReadOnlyDictionary<Square, IPiece> position)
        {
            if (square is null) return null;

            if(!(position.TryGetValue(square, out var attackedPiece)))
                return new Move(originSquare, square, MoveType.Normal);

            if(attackedPiece.Color != position[originSquare].Color)
                return new Move(originSquare, square, MoveType.Capture);

            return null;     
        }


        /// <summary>
        /// Attack all squares through a certain direction, based on their distance from 
        /// <paramref name="originSquare"/>.
        /// </summary>
        /// <param name="originSquare">Attacker square, based on 
        /// <paramref name="position"/>.</param>
        /// <param name="orientation">Attack orientation.</param>
        /// <param name="sense">True if the attack sense follows the orientation.
        /// False otherwise.</param>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        private static IEnumerable<Move> Attack(
            this Square originSquare,
            Through orientation,
            bool sense,
            IReadOnlyDictionary<Square, IPiece> position)
        {
            var moves = new List<Move>();

            int numberOfSquares = 1;

            var move = originSquare.AttackSquare(
                originSquare.Maneuver(
                    orientation, sense ? numberOfSquares : -numberOfSquares), 
                position);

            while(move is not null)
            {
                yield return move;

                if (move.Type is MoveType.Capture) yield break;

                move = originSquare.AttackSquare(
                originSquare.Maneuver(
                    orientation, sense ? (numberOfSquares+=1) : -(numberOfSquares+=1)), 
                position); 
            }   
        }    
    }
}