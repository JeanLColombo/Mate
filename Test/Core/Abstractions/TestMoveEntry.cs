using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Abstractions
{
    public class TestMoveEntry
    {
        [Fact]
        public void TestMoveEntryConstruction()
        {
            var b = new Board();
            var m = new Move(
                new Square(Files.a, Ranks.one), 
                new Square(Files.b,Ranks.one), 
                MoveType.Normal);
            
            var moveEntry = new MoveEntry(m, b.Position);

            Assert.Empty(moveEntry.Position);
            Assert.Equal(m, moveEntry.Move);
        }

        [Fact]
        public void TestMoveEntryStoresThePast()
        {
            var b = new Board();
            var m = new Move(
                new Square(Files.a, Ranks.one), 
                new Square(Files.b,Ranks.one), 
                MoveType.Normal);
            
            var moveEntry = new MoveEntry(m, b);   

            b.AddPiece<MockedPiece>(new Square(Files.a, Ranks.one), true);

            Assert.Empty(moveEntry.Position);
        }
    }
}