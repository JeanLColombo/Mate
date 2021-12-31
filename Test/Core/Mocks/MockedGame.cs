using System.Linq;
using Mate.Core.Abstractions;

namespace Mate.Tests.Core.Mocks
{
    /// <summary>
    /// Implements a mocked game of chess. 
    /// </summary>
    public class MockedGame : Game
    {
        /// <summary>
        /// Creates a new <see cref="MockedChess"/> instance. 
        /// </summary>
        /// <param name="currentMove"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="rules"></param>
        public MockedGame(int currentMove, bool currentPlayer, IChess rules)
            : base(currentMove, currentPlayer, rules) { }

        /// <summary>
        /// If <paramref name="move"/> is available, return <see langword="true"/>. 
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override bool ProcessMove(Move move)
            => ((IGame)this).AvailableMoves().Contains(move);
    }
}