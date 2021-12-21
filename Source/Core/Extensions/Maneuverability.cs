using System;
using System.Linq;
using Core.Abstractions;
using Core.Elements;
using Core.Extensions;

namespace Core.Extensions
{
    /// <summary>
    /// Provides extension methods for maneuvers in a chess <see cref="Board"/>. 
    /// </summary>
    public static class Maneuverability
    {
        /// <summary>
        /// Returns the destination <see cref="Square"/> by moving a certain <paramref name="numberOfFiles"/>
        /// and a certain <paramref name="numberOfRanks"/> from origin <paramref name="square"/>.
        /// </summary>
        /// <param name="square">Origin square.</param>
        /// <param name="numberOfFiles">Number of <see cref="Files"/>. A negative number indicates a change
        /// in sense.</param>
        /// <param name="numberOfRanks">Number of <see cref="Ranks"/>. A negative number indicates a change
        /// in sense.</param>
        /// <returns>Destination square.</returns>
        public static Square MovePlus(this Square square, int numberOfFiles, int numberOfRanks)
        {
            var newFile = (int)square.File + numberOfFiles;
            var newRank = (int)square.Rank + numberOfRanks;

            if (!Enum.IsDefined(typeof(Files), newFile) || !Enum.IsDefined(typeof(Ranks), newRank))
                return null;

            return new Square(
                (Files)newFile,
                (Ranks)newRank);
        }

        /// <summary>
        /// Returns the destination <see cref="Square"/> by moving a certain <paramref name="numberOfSquares"/>
        /// through an <paramref name="orientation"/> from origin <paramref name="square"/>.
        /// </summary>
        /// <param name="square">Origin square.</param>
        /// <param name="orientation">The move orientation.</param>
        /// <param name="numberOfSquares">Number of squares. A negative number indicates a change in sense.</param>
        /// <returns></returns>
        public static Square Maneuver(
            this Square square, 
            Through orientation, 
            int numberOfSquares) 
            => orientation switch 
            {
                Through.Files               => square.MovePlus(numberOfSquares, 0),
                Through.Ranks               => square.MovePlus(0, numberOfSquares),
                Through.MainDiagonal        => square.MovePlus(numberOfSquares, numberOfSquares),
                Through.OppositeDiagonal    => square.MovePlus(-numberOfSquares, numberOfSquares),
                _                           => 
                    throw new ArgumentException(
                        message: "Invalid enum parameter", 
                        paramName: nameof(orientation))
            };     

    
        /// <summary>
        /// Process the given <paramref name="move"/>, according to the rules of a given 
        /// game of <paramref name="chess"/>.
        /// </summary>
        /// <param name="chess">The <see cref="Chess"/> game rules.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <param name="piece">A reference to a possibly captured piece.</param>
        /// <returns><see langword="true"/> if the move was processed correctly. Otherwise, 
        /// returns <see langword="false"/>.</returns>
        public static bool Process(this Chess chess, Move move, out IPiece piece)
        {
            //TODO: test/implement this method.
            //TODO: Thrown exception on not available move?
            piece = null;

            // If move is not available, return
            if (!(new bool[]{true, false}
                .SelectMany(c => chess.AvailableMoves(c)).ToList())
                .Contains(move))
                return false;

            chess.Add(new MoveEntry(move, chess.Position));

            switch (move.Type)
            {
                case MoveType.Capture:
                    break;
                case MoveType.Passant:
                    break;
                case MoveType.Castle:
                    break;
                case MoveType.PromoteToKnight:
                    break;
                case MoveType.PromotToBishop:
                    break;
                case MoveType.PromoteToRook:
                    break;
                case MoveType.PromoteToQueen:
                    break;
                default:
                    // Proccess Normal and Rush moves
                    chess.ProcessNormal(move);
                    break;
            } 
            return false;
        }

        /// <summary>
        /// Process a <see cref="MoveType.Normal"/> <paramref name="move"/>, according to the
        /// given <paramref name="chess"/> rules. 
        /// </summary>
        /// <param name="chess">The <see cref="Chess"/> game rules.</param>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <returns><see langword="true"/> if the move was processed correctly. Otherwise, 
        /// returns <see langword="false"/>.</returns>
        private static void ProcessNormal(this Chess chess, Move move)
        {
            // Sets reference to moved piece
            IPiece piece;

            // Removes piece from one square...
            chess.RemovePiece(move.FromSquare, out piece);

            // ... to another square.
            chess.AddPiece(move.ToSquare, piece);
        }

    }
}