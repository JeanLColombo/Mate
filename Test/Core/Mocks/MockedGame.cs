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
        /// Executes the given move for current player. 
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override bool ProcessMove(Move move)
        {
            if (!Chess.AvailableMoves(CurrentPlayer).Contains(move))
                return false;
                
            return Chess.Process(move, out IPiece piece);
        }
    }
}