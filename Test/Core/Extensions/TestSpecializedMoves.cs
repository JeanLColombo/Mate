using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions
{
    public class TestSpecializedMoves
    {
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
        public void TestPawnFirstMove()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            var movePawn1 = board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position);
            var movePawn2 = board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position);

            Assert.All(
                new []{movePawn1, movePawn2}, 
                m => 
                    {
                        Assert.NotNull(m);
                        Assert.Equal(MoveType.Normal, m.Type);
                    });
            
            Assert.True(new Square(Files.a, Ranks.two).IsSameSquareAs(movePawn1.FromSquare));
            Assert.True(new Square(Files.h, Ranks.seven).IsSameSquareAs(movePawn2.FromSquare));

            Assert.True(new Square(Files.a, Ranks.four).IsSameSquareAs(movePawn1.ToSquare));
            Assert.True(new Square(Files.h, Ranks.five).IsSameSquareAs(movePawn2.ToSquare));
        }

        [Fact]
        public void TestPawnFirstMoveNotOnPawn()
        {
            var board = new Board();

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.two), true);

            Assert.Null(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstNotOnPosition()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.three), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.six), false);

            Assert.Null(board.Position[new Square(Files.a, Ranks.three)].PawnFirstMove(board.Position));
            Assert.Null(board.Position[new Square(Files.h, Ranks.six)].PawnFirstMove(board.Position));
        }

        [Fact] 
        public void TestPawnFirstMovePawnIsBlocked()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.three), true);
            board.AddPiece<MockedPiece>(new Square(Files.h, Ranks.six), true);

            Assert.Null(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
            Assert.Null(board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstMoveIsOccupied()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.four), true);
            board.AddPiece<MockedPiece>(new Square(Files.h, Ranks.five), true);

            Assert.Null(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
            Assert.Null(board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position));
        }

    }
}