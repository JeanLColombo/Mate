using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Tests.Core.Mocks
{
    public class MockedChess : Chess
    {
        /// <summary>
        /// Returns an empty collection of <see cref="Move"/>s.
        /// </summary>
        /// <param name="color">Player color.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(bool color) 
            => Enumerable.Empty<Move>().ToArray();
        
    }
}