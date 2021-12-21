using System;
using Core.Abstractions;
using Core.Elements;

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
    }
}