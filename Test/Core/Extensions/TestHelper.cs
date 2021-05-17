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
            var l = new List<IPiece>();

            l.AddNonNull(new MockedPiece(true));    

            Assert.Single(l);
        }

        [Fact]
        public void TestAddingNullToList()
        {
            var l = new List<IPiece>();

            l.AddNonNull(null);    

            Assert.Empty(l);
        }
    }
}