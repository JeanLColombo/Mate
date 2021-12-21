using System.Linq;
using Core.Abstractions;
using Core.Elements.Pieces;

namespace Core.Extensions
{
    /// <summary>
    /// Provides extension methods for check and <see cref="Move"/> legality checking in 
    /// a <see cref="Game"/> of <see cref="Chess"/>.
    /// </summary>
    public static class Legality
    {
        /// <summary>
        /// Checks if <paramref name="player"/> is currently under check.
        /// </summary>
        /// <param name="chess">A <see cref="Chess"/> board.</param>
        /// <param name="player"><see langword="true"/> for player with white pieces. Otherwise, black.</param>
        /// <returns></returns>
        public static bool IsChecked(this IChess chess, bool player)
        {
            // Types of movements that might threaten a king.
            // A pawn may promote while threatening.
            var threateningMoves = new MoveType[] {
                MoveType.Capture,
                MoveType.PromoteToKnight,
                MoveType.PromotToBishop,
                MoveType.PromoteToRook,
                MoveType.PromoteToQueen }.ToList();

            // List of opponent's moves that might threaten the king.
            var enemyMoves = chess
                .AvailableMoves(!player)
                .Where(m => threateningMoves.Contains(m.Type))
                .Where(m => chess.Position.ContainsKey(m.ToSquare))
                .Where(m => chess.Position[m.ToSquare] is King).ToList();

            // Case enemy moves is an empty list, no piece threatens the king. 
            return enemyMoves.Count > 0;
        }

        //TODO: Implement IsLegal.

        /// <summary>
        /// Checks if a <paramref name="move"/> is legal (does not place own king under check).
        /// </summary>
        /// <param name="chess">A <see cref="Chess"/> board.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns></returns>
        public static bool IsLegal(this Chess chess, Move move)
            => true;
    }

}