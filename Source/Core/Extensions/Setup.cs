using System;
using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;

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
        /// <typeparam name="TPiece"><typeparamref name="TPiece"/> must inherited 
        /// from <see cref="Piece"/>.</typeparam>
        /// <returns>True if a new <typeparamref name="TPiece"/> was 
        /// properly created.</returns>
        public static bool AddPiece<TPiece>(this Board board, Square square, bool color) where TPiece : Piece
        {
            if (square is null) return false;
            
            if (board.Position.TryGetValue(square, out var piece))
                return false;

            board.Pieces[square] = (TPiece)Activator.CreateInstance(typeof(TPiece), new object[] {color});    

            return true;       
        }

        /// <summary>
        /// Copies the give <paramref name="position"/> to <paramref name="board"/>.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="position"></param>
        public static void Copy(this Board board, IReadOnlyDictionary<Square,IPiece> position)
            => position
                .Select(kv => 
                    board.Pieces[kv.Key] = 
                        (IPiece)Activator.CreateInstance(
                            kv.Value.GetType(), 
                            new object[] {kv.Value.Color}))
                .ToList();
        
    }
}