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
        /// Appends each element of <paramref name="value"/> to the end of <paramref name="list"/>.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="values"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IReadOnlyCollection<T> Append<T>(
            this IReadOnlyCollection<T> list, 
            IReadOnlyCollection<T> values) 
            => list.ToList().Union(values.ToList()).ToList();
    }
}