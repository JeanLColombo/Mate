using System;

namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Defines a <see cref="Square"/>, and its basic properties.
    /// </summary>
    public class Square : Tuple<Files, Ranks>
    {   
        /// <summary>
        /// Returns a value indicating the <see cref="Square"/>'s <see cref="Files"/>.
        /// </summary>
        /// <value></value>
        public Files File { get => Item1; }

        /// <summary>
        /// Returns a value indicating the <see cref="Square"/>'s <see cref="Ranks"/>.
        /// </summary>
        /// <value></value>
        public Ranks Rank { get => Item2; }

        /// <summary>
        /// Returns value indicating the <see cref="Square"/>' color.
        /// </summary>
        /// <returns><c>true</c> if the <see cref="Square"/> is white. <c>false</c> otherwise.</returns>            
        public bool Color { get => GetColor(); }  

        /// <summary>
        /// Builds a new <see cref="Square"/> with given <see cref="Files"/> File and <see cref="Ranks"/> Rank.
        /// </summary>
        /// <param name="f">Set the <see cref="Square"/>'s File.</param>
        /// <param name="r">Set the <see cref="Square"/>'s Rank.</param>
        /// <returns></returns>
        public Square(Files f, Ranks r) : base(f, r) {}

        /// <summary>
        /// Builds a new <see cref="Square"/> from a given <paramref name="square"/>.
        /// </summary>
        /// <param name="square">New <see cref="File"/> and <see cref="File"/> will be 
        /// the same as <paramref name="square.File"/> and 
        /// <paramref name="square.Rank"/>.</param>
        /// <returns></returns>
        public Square(Square square) : this(square.File, square.Rank) {}

        /// <summary>
        /// Indicates if two <see cref="Square"/>'s have the same File.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsSameFileAs(Square p) => (this.File == p.File);

        /// <summary>
        /// Indicates if two <see cref="Square"/>'s have the same Rank.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsSameRankAs(Square p) => (this.Rank == p.Rank);

        /// <summary>
        /// Indicates if two <see cref="Square"/>'s have the same File and Rank.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsSameSquareAs(Square p) => (IsSameFileAs(p) && IsSameRankAs(p));

        /// <summary>
        /// <see cref="Square"/> color is a function of its <see cref="File"/> and <see cref="Rank"/>.
        /// </summary>
        /// <returns></returns>
        private bool GetColor() =>
            ((int) File % 2 == 0) ^ 
            ((int) Rank % 2 == 0);        
    }
}