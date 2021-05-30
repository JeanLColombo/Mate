using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Tests.Core.Mocks
{
    /// <summary>
    /// Implements a Mock for <see cref="Royalty"/>.
    /// </summary>
    public class MockedRoyalPiece : Royalty
    {

        /// <summary>
        /// Creates a new <see cref="MockedRoyalPiece"/> for <see cref="Royalty"/>.
        /// </summary>
        /// <param name="color"><see cref="Royalty"/> color.</param>
        /// <returns></returns>
        public MockedRoyalPiece(bool color) : base(color) {}

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