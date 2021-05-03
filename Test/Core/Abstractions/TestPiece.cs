using System.Collections.Generic;
using Xunit;
using Core.Abstractions;

namespace Tests.Core.Abstractions
{
    public class TestPiece
    {
        [Fact]
        public void TestPieceConstruction()
        {
            var p = new MockedPiece(true);       
            p.AvailableMoves(new Dictionary<Square,IPiece>());     
        }

        [Fact]
        public void TestIPieceInterface()
        {
            IPiece p = new MockedPiece(false);
            Assert.Empty(p.AvailableMoves(new Dictionary<Square,IPiece>()));

        }
    }
}
