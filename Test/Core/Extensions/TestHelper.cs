using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements;
using Mate.Core.Extensions;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Extensions
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

        [Fact]
        public void TestInBetweenSquaresOnDifferentRanks() =>
            Assert.Throws<ArgumentException>(() =>
                new Square(Files.a, Ranks.one)
                .InBetweenSquares(
                    new Square(Files.h, Ranks.eight)
                ));

        [Fact]
        public void TestInBetweenSquaresAreTheSame() =>
            Assert.Throws<ArgumentException>(() =>
                new Square(Files.a, Ranks.one)
                .InBetweenSquares(
                    new Square(Files.a, Ranks.one)
                ));

        [Theory]
        [MemberData(nameof(SquareData))]
        public void TestInBetweenSquares(
            Square sk,
            Square sr,
            IReadOnlyCollection<Square> squares
        )
        {
            var squaresKing = sk.InBetweenSquares(sr); 
            var squaresRook = sk.InBetweenSquares(sr);

            Assert.Equal(squares.Count, squaresKing.Count);
            Assert.Equal(squares.Count, squaresRook.Count);

            Assert.All(squares, (s) => 
                {
                    Assert.Contains(s, squaresKing);
                    Assert.True(sk.IsSameRankAs(s));
                });

            Assert.All(squaresKing, (s) => 
                Assert.Contains(s, squaresRook));
        }

        public static IEnumerable<object[]> SquareData => new []{
            new object[]
            {
                new Square(Files.a, Ranks.one),
                new Square(Files.d, Ranks.one),
                new List<Square>() {
                    new Square(Files.b, Ranks.one),
                    new Square(Files.c, Ranks.one)
                }               
            },
            new object[]
            {
                new Square(Files.d, Ranks.two),
                new Square(Files.e, Ranks.two),
                new List<Square>() {
                }               
            },
            new object[]
            {
                new Square(Files.d, Ranks.eight),
                new Square(Files.h, Ranks.eight),   
                new List<Square>() {
                    new Square(Files.e, Ranks.eight),
                    new Square(Files.f, Ranks.eight),
                    new Square(Files.g, Ranks.eight)
                } 
            }
        };
    }
}