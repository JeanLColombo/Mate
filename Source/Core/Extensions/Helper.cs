using System.Collections.Generic;

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
    }
}