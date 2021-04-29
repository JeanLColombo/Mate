using System;

namespace Core.Abstractions
{
    /// <summary>
    /// Defines a <c>Square</c>, and its basic properties.
    /// </summary>
    public class Square : Tuple<Files, Ranks>
    {   
        /// <summary>
        /// Returns a value indicating the Square's <c>Files</c>.
        /// </summary>
        /// <value></value>
        public Files File { get => Item1; }

        /// <summary>
        /// Returns a value indicating the Square's <c>Ranks</c>.
        /// </summary>
        /// <value></value>
        public Ranks Rank { get => Item2; }

        /// <summary>
        /// Returns <c>True</c> if the Square is white. <c>False</c> otherwise.
        /// </summary>
        /// <returns></returns>            
        public bool Color { get => GetColor(); }  

        /// <summary>
        /// Builds a new <c>Square</c> with given File and Rank.
        /// </summary>
        /// <param name="f">Set the <c>Square</c>'s File.</param>
        /// <param name="r">Set the <c>Square</c>'s Rank.</param>
        /// <returns></returns>
        public Square(Files f, Ranks r) : base(f, r) {}

        /// <summary>
        /// Indicates if two <c>Square</c>s have the same File.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsSameFileAs(Square p) => (this.File == p.File);

        /// <summary>
        /// Indicates if two <c>Square</c>s have the same Rank.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsSameRankAs(Square p) => (this.Rank == p.Rank);

        /// <summary>
        /// Indicates if two <c>Square</c>s have the same File and Rank.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsSameSquareAs(Square p) => (IsSameFileAs(p) && IsSameRankAs(p));

        /// <summary>
        /// <c>Square</c> color is a function of its File and Rank <c>int</c> values.
        /// </summary>
        /// <returns></returns>
        private bool GetColor() =>
            ((int) File % 2 == 0) ^ 
            ((int) Rank % 2 == 0);        
    }
}