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
        /// and a cerntain <paramref name="numberOfRanks"/> from origin <paramref cref="square"/>.
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
        /// Return a destination <see cref="Square"/>, by moving a certain <paramref name="numberOfFiles"/>
        /// from a origin <paramref name="square"/>.
        /// </summary>
        /// <param name="square">Origin square.</param>
        /// <param name="numberOfFiles">Number of <see cref="Files"/>. A negative number indicates a change
        /// in sense.</param>
        /// <returns>Destination square.</returns>
        public static Square MoveThroughFiles(this Square square, int numberOfFiles) 
            => square.MovePlus(numberOfFiles, 0);

        /// <summary>
        /// Return a destination <see cref="Square"/>, by moving a certain <paramref name="numberOfRanks"/>
        /// from a origin <paramref name="square"/>.
        /// </summary>
        /// <param name="square">Origin square.</param>
        /// <param name="numberOfRanks">Number of <see cref="Ranks"/>. A negative number indicates a change
        /// in sense.</param>
        /// <returns>Destination square.</returns>
        public static Square MoveThroughRanks(this Square square, int numberOfRanks) 
            => square.MovePlus(0, numberOfRanks);

        /// <summary>
        /// Return a destination <see cref="Square"/>, by moving a certain <paramref name="numberOfSquares"/>
        /// through the main diagonal, from a origin <paramref name="square"/>.
        /// </summary>
        /// <param name="square">Origin square.</param>
        /// <param name="numberOfSquares">Number of squares. A negative number indicates a change
        /// in sense.</param>
        /// <returns>Destination square.</returns>
        public static Square MoveThroughMainDiagonal(this Square square, int numberOfSquares) 
            => square.MovePlus(numberOfSquares, numberOfSquares);   

        /// <summary>
        /// Return a destination <see cref="Square"/>, by moving a certain <paramref name="numberOfSquares"/>
        /// through the opposite diagonal, from a origin <paramref name="square"/>.
        /// </summary>
        /// <param name="square">Origin square.</param>
        /// <param name="numberOfSquares">Number of squares. A negative number indicates a change
        /// in sense.</param>
        /// <returns>Destination square.</returns>
        public static Square MoveThroughOppositeDiagonal(this Square square, int numberOfSquares) 
            => square.MovePlus(-numberOfSquares, numberOfSquares);     
    }
}