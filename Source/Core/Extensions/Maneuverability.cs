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
        /// Return a destination <see cref="Square"/>, by moving a certain <paramref name="numberOfSquare"/>
        /// in <typeparamref name="T"/> direction from a origin <paramref name="square"/>. 
        /// </summary>
        /// <param name="square">Origin square.</param>
        /// <param name="numberOfSquares">Number of squares. A negative number means a
        /// change in sense.</param>
        /// <typeparam name="T">Either <see cref="Files"/> or <see cref="Ranks"/>.</typeparam>
        /// <returns>Destination square.</returns>
        public static Square MoveThrough<T>(this Square square, int numberOfSquares)
        {
            //TODO: Finish this method.
            var newFile = (int)square.File;
            var newRank = (int)square.Rank;
            
            if (typeof(T) == typeof(Files))
                newFile += numberOfSquares;
            else if (typeof(T) == typeof(Ranks))
                newRank += numberOfSquares;
            else
                throw new ApplicationException("T must be Files or Ranks");
            
            return new Square(Files.a,Ranks.one);

        }

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

        //TODO: test this method.
    }
}