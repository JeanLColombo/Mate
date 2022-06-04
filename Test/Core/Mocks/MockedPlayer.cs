using Mate.Core.Abstractions;

namespace Mate.Tests.Core.Mocks
{
    /// <summary>
    ///  Implements a mocked <see cref="Player"/> playing a <see cref="IGame"/> of <see cref="IChess"/>.
    /// </summary>
    public class MockedPlayer : Player
    {
        public override Outcome Resign(IMatch match)
        {
            throw new System.NotImplementedException();
        }

        public override Outcome Draw(IMatch match)
        {
            throw new System.NotImplementedException();
        }

        public override bool Play(IMatch match, Move move)
        {
            throw new System.NotImplementedException();
        }
    }
}
