using System;
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
            IMatch match = new MockedMatch();

            Assert.Throws<NotImplementedException>(() => player.Resign(match));
            Assert.Throws<NotImplementedException>(() => player.Draw(match));
            Assert.Throws<NotImplementedException>(() => 
                player.Play(
                    match,
                    new Move(
                        new Square(Files.a, Ranks.one), 
                        new Square(Files.a, Ranks.two), 
                        MoveType.Normal)));
        }
    }
}