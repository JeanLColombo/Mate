using System;
using System.Collections.Generic;
using System.Linq;
using Mate.Core.Abstractions;
namespace Mate.Core.Extensions
{
    /// <summary>
    /// Provide helper extensions for managing the core library.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Adds a non-null value at the end of the <paramref name="list"/>.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public static bool AddNonNull<T>(this HashSet<T> list, T value) 
            => (value is null) ? false : list.Add(value);
            

        /// <summary>
        /// Creates a new read-only collection containing all 
        /// <typeparamref name="T"/> items in <paramref name="firstCollection"/> and 
        /// in <paramref name="secondCollection"/>, while excluding duplicates.
        /// </summary>
        /// <param name="firstCollection"></param>
        /// <param name="secondCollection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IReadOnlyCollection<T> Unify<T>(
            this IReadOnlyCollection<T> firstCollection, 
            IReadOnlyCollection<T> secondCollection) 
            => firstCollection.ToList().Union(secondCollection.ToList()).ToList();

        /// <summary>
        /// Checks if <paramref name="piece" /> has moved.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="position">A given <see cref="Core.Elements.Board.Position"/>.</param>
        /// <param name="moveEntries">A read-only <see cref="MoveEntry"/> collection of 
        /// previously proccessed moves.</param>
        /// <returns></returns>
        public static bool HasMoved(
            this IPiece piece, 
            IReadOnlyDictionary<Square,IPiece> position, 
            IReadOnlyCollection<MoveEntry> moveEntries) 
        {
            var s = ((Piece)piece).GetSquareFrom(position);
            
            return !((moveEntries.Count == 0) || (s is null) || (moveEntries.Select(me => me.Move).FirstOrDefault(m => m.ToSquare.IsSameSquareAs(s)) is null));
        }

        /// <summary>
        /// Returns all <see cref="Square"/>'s on the same rank between two files.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        /// <exception  cref="ArgumentException">Throws an exception when s1 are s2
        /// ar on the different <see cref="Ranks"/> or when they are the same 
        /// <see cref="Square"/>.</exception >
        public static IReadOnlyCollection<Square> InBetweenSquares(
            this Square s1, 
            Square s2)
        {
            if (!s1.IsSameRankAs(s2) || s1.IsSameSquareAs(s2)) 
                throw new ArgumentException(
                    "Squares are either on different ranks or ar the same", 
                    nameof(s2)); 

            return Enumerable
                .Range(1, (Math.Abs((int)s1.File - (int)s2.File) - 1))
                .Select(i => (s1.File < s2.File) ? i : - i)
                .Select(nf => s1.Maneuver(Through.Files, nf))
                .ToList();
        }
    }
}