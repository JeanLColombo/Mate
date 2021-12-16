using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements.Rules;

namespace Test.Core.Elements.Rules
{
    public class TestCustom 
    {
        [Fact]
        public void TestDefaultConstructor()
        {
            var chess = new Custom(new Dictionary<Square, IPiece>());
            Assert.Empty(chess.Position);
            Assert.Empty(chess.BannedMoves);
            Assert.Empty(chess.Position);
            //TODO: Implement chess legality.
            //TODO: Implement Process Move.
            // Assert.All(new []{false, true}, c => Assert.Empty(chess.AvailableMoves(c)));
        }
    }
}