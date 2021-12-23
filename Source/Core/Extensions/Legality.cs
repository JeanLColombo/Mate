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
        /// <typeparam name="TChess">Derived type. <paramref name="chess"/> 
        /// must be <typeparamref name="TChess"/>.</typeparam>
        /// <param name="chess">A <see cref="Chess"/> board.</param>
        /// <param name="player"><see langword="true"/> for player with white pieces. Otherwise, black.</param>
        /// <returns><see langword="true"/> if <paramref name="player"/> is checked. 
        /// Otherwise, <see langword="false"/>.</returns>
        public static bool IsChecked<TChess>(this IChess chess, bool player) where TChess : Chess 
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
            var enemyMoves = ((TChess)chess)
                .AllMoves(!player)
                .Where(m => threateningMoves.Contains(m.Type))
                .Where(m => chess.Position.ContainsKey(m.ToSquare))
                .Where(m => chess.Position[m.ToSquare] is King).ToList();

            // Case enemy moves is an empty list, no piece threatens the king. 
            return enemyMoves.Count > 0;
        }

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

            // Legal logic for castle 
            if (move.Type == MoveType.Castle)
                return chessInstance.IsCastlingLegal<TChess>(move);


            // ... use it to get moved IPiece color 
            var color = chessInstance.Position[move.FromSquare].Color;

            // Execute given move on instance...
            chessInstance.Process(move, out IPiece piece);

            // ... and returns wether own king is not checked  
            return !chessInstance.IsChecked<TChess>(color);
        }

        /// <summary>
        /// Checks if castling is legal or not, for a given castles <paramref name="move"/>.
        /// </summary>
        /// <typeparam name="TChess">Derived type. <paramref name="chess"/> 
        /// must be <typeparamref name="TChess"/>.</typeparam>
        /// <param name="chess">A given set of <see cref="Chess"/> rules.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns><see langword="true"/> if the move is legal. 
        /// Otherwise, <see langword="false"/>.</returns>
        private static bool IsCastlingLegal<TChess>(this IChess chess, Move move) where TChess : Chess

        {
            // Get the castling king
            var king = chess.Position[move.FromSquare];
            
            // Castle can't occur when king is checked
            if (chess.IsChecked<TChess>(king.Color)) return false;

            // Define the type of castle 
            var kingSideCastle = move.ToSquare.File == Files.g;

            // Determines the rook squares
            var rookFromSquare = new Square(
                kingSideCastle ? Files.h : Files.a,
                move.FromSquare.Rank
            );
            var rookToSquare = new Square(
                kingSideCastle ? Files.f : Files.d,
                move.ToSquare.Rank
            );

            // Remove rook
            ((Chess)chess).RemovePiece(rookFromSquare, out IPiece rook);

            // Get all squares between fromSquare and toSquare
            var currentSquare = new Square(move.FromSquare);
            var kingSquares = Helper
                .InBetweenSquares(move.FromSquare, move.ToSquare)
                .ToList()
                .Append(move.ToSquare)
                .ToList();

            // Loop and test for checks
            foreach (var square in kingSquares)
            {
                // Move king along the castling path...
                if (!chess.Process(
                    new Move(
                        currentSquare,
                        square,
                        MoveType.Normal),
                    out IPiece p))
                    return false;

                // ... and check for checks.
                if (chess.IsChecked<TChess>(king.Color))
                    return false;

                currentSquare = new Square(square);
            }

            // Put rook at his destination square
            ((Chess)chess).PlaceAt(rookToSquare, rook);

            return true;
        }

    }

}