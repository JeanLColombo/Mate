using System.Collections.Generic;
using System.Linq;
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
                        Assert.Single(m);
                        Assert.Equal(MoveType.Normal, m.First().Type);
                    });
            
            Assert.True(new Square(Files.a, Ranks.two).IsSameSquareAs(movePawn1.First().FromSquare));
            Assert.True(new Square(Files.h, Ranks.seven).IsSameSquareAs(movePawn2.First().FromSquare));

            Assert.True(new Square(Files.a, Ranks.four).IsSameSquareAs(movePawn1.First().ToSquare));
            Assert.True(new Square(Files.h, Ranks.five).IsSameSquareAs(movePawn2.First().ToSquare));
        }

        [Fact]
        public void TestPawnFirstMoveNotOnPawn()
        {
            var board = new Board();

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.two), true);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstNotOnPosition()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.three), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.six), false);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.three)].PawnFirstMove(board.Position));
            Assert.Empty(board.Position[new Square(Files.h, Ranks.six)].PawnFirstMove(board.Position));
        }

        [Fact] 
        public void TestPawnFirstMovePawnIsBlocked()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.three), true);
            board.AddPiece<MockedPiece>(new Square(Files.h, Ranks.six), true);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
            Assert.Empty(board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstMoveIsOccupied()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.four), true);
            board.AddPiece<MockedPiece>(new Square(Files.h, Ranks.five), true);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
            Assert.Empty(board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstMoveWhenNotInPosition()
        {
            var board = new Board();

            var pawn = new Pawn(true);

            var v = pawn.PawnFirstMove(board.Position);
        }

        [Fact]
        public void TestEnPassantOnNotPawn() =>
            Assert.Empty(
                new MockedPiece(true)
                .EnPassant(
                    new Board().Position, 
                    new List<MoveEntry>(){
                        new MoveEntry(
                            new Move(
                                new Square(Files.a, Ranks.one), 
                                new Square(Files.a, Ranks.two), 
                                MoveType.Normal),
                            new Board().Position)
                        }));
        
        [Fact]
        public void TestEnPassantWithNoMoveEntries() =>
            Assert.Empty(
                new Pawn(true).EnPassant(
                    new Board().Position,
                    Enumerable.Empty<MoveEntry>().ToList()));

        [Fact]
        public void TestEnPassantLastPieceMovedIsNotPawn()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<MockedPiece>(new Square(Files.c, Ranks.one), false);

            var moveEntries = new List<MoveEntry>() {
                new MoveEntry(
                    new Move(
                        new Square(Files.c, Ranks.two), 
                        new Square(Files.c, Ranks.one), 
                        MoveType.Normal), 
                    board.Position)};
            
            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.two)]
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantFromOffTheBoard()
        {
            var board = new Board();

            board.AddPiece<MockedPiece>(new Square(Files.c, Ranks.one), false);

            var moveEntries = new List<MoveEntry>() {
                new MoveEntry(
                    new Move(
                        new Square(Files.c, Ranks.two), 
                        new Square(Files.c, Ranks.one), 
                        MoveType.Normal), 
                    board.Position)};
            
            Assert.Empty(
                new Pawn(true)
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantPawnNotOnCorrectRank()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.b, Ranks.three), false);

            var moveEntries = new List<MoveEntry>() {
                new MoveEntry(
                    new Move(
                        new Square(Files.b, Ranks.four), 
                        new Square(Files.b, Ranks.three), 
                        MoveType.Normal), 
                    board.Position)};    

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.two)]
                .EnPassant(board.Position, moveEntries));
            
            moveEntries.Add(
                new MoveEntry(
                    new Move(
                        new Square(Files.a, Ranks.one),
                        new Square(Files.a, Ranks.two),
                        MoveType.Normal),
                    board.Position));

            Assert.Empty(
                board.Position[new Square(Files.b, Ranks.three)]
                .EnPassant(board.Position, moveEntries));
        }    
    }
}