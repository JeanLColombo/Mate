using System;
using Core.Abstractions;
using Core.Elements;

namespace Core.Extensions
{
    /// <summary>
    /// Provide extension methods for setting up new pieces on the <see cref="Board"/>.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Add a new <typeparamref name="TPiece"/> of a given <paramref name="color"/> to a 
        /// given <paramref name="square"/>.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="square"></param>
        /// <param name="color">True if <typeparamref name="TPiece"/> is white. False otherwise.</param>
        /// <typeparam name="TPiece"><typeparamref name="TPiece"/> must inherherit 
        /// from <see cref="Piece"/>.</typeparam>
        /// <returns>True if a new <typeparamref name="TPiece"/> was 
        /// properly created.</returns>
        public static bool AddPiece<TPiece>(this Board board, Square square, bool color) where TPiece : Piece
        {
            if (square is null) return false;
            
            if (board.Position[square] is not null)
                return false;

            board.Pieces[square] = (TPiece)Activator.CreateInstance(typeof(TPiece), new object[] {color});    

            return true;       
        }
    }
}