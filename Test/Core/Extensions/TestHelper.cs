using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements;
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

        [Fact]
        public void TestUnify()
        {
            IReadOnlyCollection<int> listA = new []{0, 1, 2, 3};   
            IReadOnlyCollection<int> listB = new []{-1, -2, -3, -4};

            var appendedList = listA.Unify(listB);

            Assert.Equal(8, appendedList.Count);
            Assert.All(Enumerable.Range(-4, 8), (i) => Assert.Contains(i, appendedList));
        }

        [Fact]
        public void TestUnifyWithDuplicates()
        {
            IReadOnlyCollection<int> listA = new []{0, 1, 2, 3};   
            IReadOnlyCollection<int> listB = new []{1, 2, 3, 4};

            var appendedList = listA.Unify(listB);

            Assert.Equal(5, appendedList.Count);
            Assert.All(Enumerable.Range(0, 5), (i) => Assert.Contains(i, appendedList));
        }

        [Fact]
        public void TestUnifyNothing()
        {
            IReadOnlyCollection<int> listA = new []{0, 1, 2, 3};   
            IReadOnlyCollection<int> listB = Enumerable.Empty<int>().ToList();

            var appendedListA = listA.Unify(listB);
            var appendedListB = listB.Unify(listA);

            Assert.All(
                new []{appendedListA, appendedListB}, 
                (list) => Assert.Equal(4, list.Count));

            Assert.All(
                new []{appendedListA, appendedListB}, 
                (list) => Assert.All(Enumerable.Range(0, 4), 
                    (i) => Assert.Contains(i, list)));    
        }

        [Fact]
        public void TestUnifyMoveCollection()
        {
            IReadOnlyCollection<Move> movesA = new []{
                new Move(
                    new Square(Files.a, Ranks.one), 
                    new Square(Files.a, Ranks.two), 
                    MoveType.Normal),
                new Move(
                    new Square(Files.a, Ranks.one), 
                    new Square(Files.b, Ranks.two), 
                    MoveType.Normal)
            };

            IReadOnlyCollection<Move> movesB = new []{
                new Move(
                    new Square(Files.a, Ranks.one), 
                    new Square(Files.a, Ranks.two), 
                    MoveType.Passant),
                new Move(
                    new Square(Files.c, Ranks.one), 
                    new Square(Files.b, Ranks.two), 
                    MoveType.Capture)
            };

            var moves = movesA.Unify(movesB);

            Assert.Equal(4, moves.Count);
            Assert.All(
                new[]{movesA, movesB}, 
                (ms) => Assert.All(
                    ms, 
                    (m) => Assert.Contains(m, moves)));
        }


        [Fact]
        public void TestHasMovedWithPieceOfTheBoard() => 
            Assert.False(
                new MockedPiece(true)
                .HasMoved(
                    new Board().Position, 
                    new List<MoveEntry>()));
        
        [Fact]
        public void TestHasMovedWithNoMoveEntries()
        {
            var board = new Board();    

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.one), true);    

            Assert.False(board.Position[new Square(Files.a, Ranks.one)].HasMoved(board.Position, new List<MoveEntry>()));
        }


        [Fact]
        public void TestPieceHasNotMoved()
        {
            var board = new Board();    

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.one), true);    

            var entries = new List<MoveEntry>() {
                new MoveEntry(new Move(new Square(Files.b, Ranks.one), new Square(Files.b, Ranks.two), MoveType.Normal), board.Position),
                new MoveEntry(new Move(new Square(Files.c, Ranks.one), new Square(Files.c, Ranks.two), MoveType.Normal), board.Position)                    
            };

            Assert.False(board.Position[new Square(Files.a, Ranks.one)].HasMoved(board.Position, entries));
        }

        [Fact]
        public void TestPieceHasMoved()
        {
            var board = new Board();    

            board.AddPiece<MockedPiece>(new Square(Files.c, Ranks.two), true);    

            var entries = new List<MoveEntry>() {
                new MoveEntry(new Move(new Square(Files.a, Ranks.one), new Square(Files.b, Ranks.two), MoveType.Normal), board.Position),
                new MoveEntry(new Move(new Square(Files.c, Ranks.one), new Square(Files.c, Ranks.two), MoveType.Normal), board.Position)                    
            };

            Assert.True(board.Position[new Square(Files.c, Ranks.two)].HasMoved(board.Position, entries));
        }
    }
}