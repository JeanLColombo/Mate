using Xunit;
using Mate.Core.Abstractions;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Abstractions
{
    public class TestPlayer
    {
        [Fact]
        public void TestConstructor()
        {
            IPlayer player = new MockedPlayer();
        }
    }
}