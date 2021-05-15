using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Tests.Core.Mocks
{
    /// <summary>
    /// Implements a Mock for <see cref="Piece"/>.
    /// </summary>
    public class MockedPiece : Piece
    {

        /// <summary>
        /// Creates a new <see cref="MockPiece"/> for for <see cref="Piece"/>.
        /// </summary>
        /// <param name="color"><see cref="Piece"/> color.</param>
        /// <returns></returns>
        public MockedPiece(bool color) : base(color) {}

        /// <summary>
        /// Returns an empty collection of <see cref="Move"/>s.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(
            IReadOnlyDictionary<Square,IPiece> position) 
                => Enumerable.Empty<Move>().ToArray();
    }
}