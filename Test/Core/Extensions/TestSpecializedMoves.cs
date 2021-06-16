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

        [Fact]
        public void TestEnPassantPawnNotAdjacent()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.five), true);
            board.AddPiece<Pawn>(new Square(Files.b, Ranks.four), false);

            var moveEntries = new List<MoveEntry>() {
                new MoveEntry(
                    new Move(
                        new Square(Files.b, Ranks.five), 
                        new Square(Files.b, Ranks.four), 
                        MoveType.Normal), 
                    board.Position)};

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.five)]
                .EnPassant(board.Position, moveEntries));
            
            moveEntries.Add(
                new MoveEntry(
                    new Move(
                        new Square(Files.a, Ranks.four),
                        new Square(Files.a, Ranks.five),
                        MoveType.Normal),
                    board.Position));

            Assert.Empty(
                board.Position[new Square(Files.b, Ranks.four)]
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantNoRushForward()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.five), true);
            board.AddPiece<Pawn>(new Square(Files.b, Ranks.five), false);

            board.AddPiece<Pawn>(new Square(Files.g, Ranks.four), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.four), false);

            var moveEntries = new List<MoveEntry>() {
                new MoveEntry(
                    new Move(
                        new Square(Files.b, Ranks.six), 
                        new Square(Files.b, Ranks.five), 
                        MoveType.Normal), 
                    board.Position)};

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.five)]
                .EnPassant(board.Position, moveEntries));
            
            moveEntries.Add(
                new MoveEntry(
                    new Move(
                        new Square(Files.g, Ranks.three),
                        new Square(Files.g, Ranks.four),
                        MoveType.Normal),
                    board.Position));

            Assert.Empty(
                board.Position[new Square(Files.h, Ranks.four)]
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantAvailable()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.five), true);
            board.AddPiece<Pawn>(new Square(Files.b, Ranks.five), false);

            board.AddPiece<Pawn>(new Square(Files.g, Ranks.four), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.four), false);

            var moveEntries = new List<MoveEntry>() {
                new MoveEntry(
                    new Move(
                        new Square(Files.b, Ranks.seven), 
                        new Square(Files.b, Ranks.five), 
                        MoveType.Normal), 
                    board.Position)};

            var passant1 = board.Position[new Square(Files.a, Ranks.five)]
                .EnPassant(board.Position, moveEntries);

            Assert.Equal(new Square(Files.a, Ranks.five), passant1.First().FromSquare);
            Assert.Equal(new Square(Files.b, Ranks.six), passant1.First().ToSquare);

            moveEntries.Add(
                new MoveEntry(
                    new Move(
                        new Square(Files.g, Ranks.two),
                        new Square(Files.g, Ranks.four),
                        MoveType.Normal),
                    board.Position));

            var passant2 = board.Position[new Square(Files.h, Ranks.four)]
                .EnPassant(board.Position, moveEntries);

            Assert.Equal(new Square(Files.h, Ranks.four), passant2.First().FromSquare);
            Assert.Equal(new Square(Files.g, Ranks.three), passant2.First().ToSquare);

            Assert.All(new []{passant1, passant2}, (ep) =>{
                Assert.Single(ep);    
                Assert.Equal(MoveType.Passant, ep.First().Type);
            });

        }    
    }
}