using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Games;
using Mate.Core.Elements.Rules;

namespace Mate.Tests.Core.Elements.Games
{
    public class TestStandard 
    {
        [Fact]
        public void TestConstructor()
        {
            IGame game = new Standard<Classical>();

            Assert.Equal(0, game.Score);
            Assert.True(game.CurrentPlayer);
            Assert.Equal(0, (int)game.Move);
            Assert.Equal(20, game.AvailableMoves().Count);
        }
    }
}