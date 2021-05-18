using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions
{
    public class TestHelper 
    {
        [Fact]
        public void TestAddingNonNullToList()
        {
            var l = new HashSet<IPiece>();

            Assert.True(l.AddNonNull(new MockedPiece(true)));    

            Assert.Single(l);
        }

        [Fact]
        public void TestAddingNullToList()
        {
            var l = new HashSet<IPiece>();

            Assert.False(l.AddNonNull(null));    

            Assert.Empty(l);
        }
    }
}