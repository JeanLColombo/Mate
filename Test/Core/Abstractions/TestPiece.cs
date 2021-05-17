using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Tests.Core.Mocks;

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

        [Fact]
        public void TestGetSquareFromPosition()
        {
            var p = new MockedPiece(true);
            var position = CreatePosition(p);

            Assert.Equal(new Square(Files.a, Ranks.two), p.GetSquareFrom(position));
        }

        [Fact]
        public void TestGetSquareFromPieceNotInPosition()
        {
            var p = new MockedPiece(false);
            var position = CreatePosition();

            Assert.Null(p.GetSquareFrom(position));
        }

        private IReadOnlyDictionary<Square,IPiece> CreatePosition(IPiece p = null) 
        {
            var position = new Dictionary<Square,IPiece>();

            if(p is not null) 
                position[new Square(Files.a, Ranks.two)] = p;
            
            return position;
        }

    }
}
