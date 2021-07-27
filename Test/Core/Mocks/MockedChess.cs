using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Tests.Core.Mocks
{
    public class MockedChess : Chess
    {
        /// <summary>
        /// Mock for parameterless <see cref="Chess"/> constructor 
        /// </summary>
        /// <returns></returns>
        public MockedChess() : base() {}

        /// <summary>
        /// Mock for <see cref="Chess"/> constructor 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public MockedChess(IReadOnlyDictionary<Square,IPiece> position) : base(position) {}

        /// <summary>
        /// Returns an empty collection of <see cref="Move"/>s.
        /// </summary>
        /// <param name="color">Player color.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(bool color) 
            => Enumerable.Empty<Move>().ToArray();
        
    }
}