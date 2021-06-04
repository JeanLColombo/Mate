using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Extensions;

namespace Core.Elements.Pieces
{
    /// <summary>
    /// Implements the <see cref="Pawn"/> piece.
    /// </summary>
    public class Pawn : Royalty
    {
        /// <summary>
        /// Creates a <see cref="Pawn"/> piece of given <paramref name="color"/>.
        /// </summary>
        /// <param name="color">True for white. Black otherwise.</param>
        /// <returns></returns>
        public Pawn(bool color) : base(color) {}

        /// <summary>
        /// Returns all moves available for a <see cref="Pawn"/> based on a board <paramref name="position"/>. 
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(IReadOnlyDictionary<Square,IPiece> position) =>
            PawnAttack(position)
            .Unify(PawnMoveFoward(position))
            .SelectMany(
                m => UpdateToPromotions(m))
            .ToList();

        /// <summary>
        /// Given a <paramref name="position"/>, attacks adjacent diagnals, 
        /// according to <see cref="IPiece.Color"/>.
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns>Returns only <see cref="MoveType.Capture"/>.</returns>
        private IReadOnlyCollection<Move> PawnAttack(IReadOnlyDictionary<Square,IPiece> position) =>
            new Through[]{Through.MainDiagonal, Through.OppositeDiagonal}
                .SelectMany(o => this.Attack(o, Color, position, 1))
                .Where(m => m.Type is MoveType.Capture)
                .ToList();
        
        /// <summary>
        /// Given a <paramref name="position"/>, checks for pawn single <see cref="Square"/> 
        /// move, according to <see cref="IPiece.Color"/>.
        /// </summary>
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
        /// <returns>Returns only <see cref="MoveType.Normal"/>.</returns>
        private IReadOnlyCollection<Move> PawnMoveFoward(IReadOnlyDictionary<Square,IPiece> position) =>
            this.Attack(Through.Ranks, Color, position, 1)
                .Where(m => m.Type is MoveType.Normal)
                .ToList();

        /// <summary>
        /// Updates a <see cref="Pawn"/> <paramref name="move"/> to a list of all available promotions,
        /// depending on their <see cref="Move.ToSquare"/> and <see cref="IPiece.Color"/>.
        /// </summary>
        /// <param name="move"></param>
        /// <returns>Either a read-only collection containg <paramref name="move"/> or a list of
        /// updated moves.</returns>
        private IReadOnlyCollection<Move> UpdateToPromotions(Move move) => 
            move.ToSquare.Rank != (Color ? Ranks.eigth :  Ranks.one) ? 
                new List<Move>(){move} :
                new MoveType[]{
                    MoveType.PromoteToKnight, 
                    MoveType.PromotToBishop, 
                    MoveType.PromoteToRook, 
                    MoveType.PromoteToQueen}
                    .Select(
                        mt => 
                        new Move(move.FromSquare, move.ToSquare, mt))
                    .ToList(); 
            
    }
}