using Xunit;
using Mate.Core.Abstractions;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Abstractions
{
    public class TestMatch
    {
        [Fact]
        public void TestConstructor()
        {
            IMatch match = new MockedMatch();

            Assert.Equal(0, match.TotalGamesFinished);
        }
    }
}