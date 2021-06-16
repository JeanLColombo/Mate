using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
namespace Core.Extensions
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
        /// Creates a new <see cref="IReadOnlyCollection"/>, containing all 
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
        /// <param name="position">A given <see cref="Board.Position"/>.</param>
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
    }
}