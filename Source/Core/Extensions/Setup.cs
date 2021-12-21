using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="board">A <see cref="Chess"/><see cref="Board"/>.</param>
        /// <param name="square">A given <see cref="Square"/>.</param>
        /// <param name="color"><see langword="true"/> if <typeparamref name="TPiece"/> is white. 
        /// <see langword="false"/> otherwise.</param>
        /// <typeparam name="TPiece"><typeparamref name="TPiece"/> must inherited 
        /// from <see cref="Piece"/>.</typeparam>
        /// <returns><see langword="true"/> if a new <typeparamref name="TPiece"/> was 
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
        /// Places an existing <paramref name="piece"/> at a given <paramref name="square"/>,
        /// according to the given <paramref name="chess"/> rules.
        /// </summary>
        /// <param name="chess">The <see cref="Chess"/> game rules.</param>
        /// <param name="square">A given <see cref="Square"/>.</param>
        /// <param name="piece">A given <see cref="IPiece"/> instance.</param>
        /// <returns><see langword="true"/> if the piece was properly placed. 
        /// Otherwise, <see langword="false"/>.</returns>
        public static bool AddPiece(this Chess chess, Square square, IPiece piece)
        {
            if (chess.Position.ContainsKey(square)) return false;

            chess.PlaceAt(square, piece);

            return true;
        }

        /// <summary>
        /// Removes <paramref name="piece"/> from the given <paramref name="square"/>,
        /// according to the given <paramref name="chess"/> rules.
        /// </summary>
        /// <param name="chess">The <see cref="Chess"/> game rules.</param>
        /// <param name="square">A given <see cref="Square"/>.</param>
        /// <param name="piece">A given <see cref="IPiece"/> instance.</param>
        /// <returns><see langword="true"/> if the piece was properly removed. 
        /// Otherwise, <see langword="false"/>.</returns>
        public static bool RemovePiece(this Chess chess, Square square, out IPiece piece)
        {
            if (!chess.Position.ContainsKey(square))
            {
                piece = null;
                return false;
            }

            piece = chess.Position[square];

            chess.Clear(square);

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