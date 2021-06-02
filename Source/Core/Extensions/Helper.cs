using System;
using System.Collections.Generic;
using System.Linq;

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
        {
            if (value == null) return false;   
            
            list.Add(value);
            
            return true;
        }

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
    }
}