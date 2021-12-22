using System;
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
                MoveType.PromoteToBishop,
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

        //TODO: Implement IsLegal.j

        /// <summary>
        /// Checks if a <paramref name="move"/> is legal (does not place own king under check).
        /// </summary>
        /// <typeparam name="TChess">Derived type. <paramref name="chess"/> 
        /// must be <typeparamref name="TChess"/>.</typeparam>
        /// <param name="chess">A given set of <see cref="Chess"/> rules.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns><see langword="true"/> if the move is legal. 
        /// Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="chess"/> must
        /// be a <typeparamref name="TChess"/> instance.</exception>
        public static bool IsLegal<TChess>(this IChess chess, Move move) where TChess : Chess
        {
            // Legal restraints
            if (!(chess is TChess))
                throw new ArgumentException(
                    message: "Chess must be a TChess instance",
                    paramName: nameof(chess));


            // Create a new chess state instance...
            IChess chessInstance = (TChess)Activator.CreateInstance(
                typeof(TChess), 
                new object[] { (TChess)chess });

            // ... use it to get moved IPiece color 
            var color = chessInstance.Position[move.FromSquare].Color;

            // Castles logic
            if (move.Type == MoveType.Castle)
            {
                if (chessInstance.IsChecked(color))
                    return false;
            }

            //TODO: Add castle logic
            
            // Execute given move on instance...
            chessInstance.Process(move, out IPiece piece);

            // ... and returns wether own king is not checked  
            return !chessInstance.IsChecked(color);
        }
    }

}