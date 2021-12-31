using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements;
using Mate.Core.Elements.Pieces;
using Mate.Core.Extensions;
using Mate.Core.Extensions.SpecializedMoves;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Extensions
{
    public class TestPawnPassant
    {
        [Fact]
        public void TestEnPassantOnNotPawn() =>
            Assert.Empty(
                new MockedPiece(true)
                .EnPassant(
                    new Board().Position, 
                    new List<MoveEntry>(){
                        SimpleMoveEntry(
                            new Square(Files.a, Ranks.one), 
                            new Square(Files.a, Ranks.two), 
                            new Board())
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
                SimpleMoveEntry(
                    new Square(Files.c, Ranks.two), 
                    new Square(Files.c, Ranks.one), 
                    board)};

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.two)]
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantFromOffTheBoard()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.c, Ranks.one), false);

            var moveEntries = new List<MoveEntry>() {
                SimpleMoveEntry(
                    new Square(Files.c, Ranks.two), 
                    new Square(Files.c, Ranks.one), 
                    board)};
            
            Assert.Empty(
                new Pawn(true)
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantPawnNotOnCorrectRank()
        {
            var board = BoardPawnSetup(
                new Square(Files.a, Ranks.two), 
                new Square(Files.b, Ranks.three));

            var moveEntries = new List<MoveEntry>() {
                SimpleMoveEntry(
                    new Square(Files.b, Ranks.four), 
                    new Square(Files.b, Ranks.three), 
                    board)};

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.two)]
                .EnPassant(board.Position, moveEntries));
            
            moveEntries.Add(
                SimpleMoveEntry(
                    new Square(Files.a, Ranks.one), 
                    new Square(Files.a, Ranks.two), 
                    board));

            Assert.Empty(
                board.Position[new Square(Files.b, Ranks.three)]
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantPawnNotAdjacent()
        {
            var board = BoardPawnSetup(
                new Square(Files.a, Ranks.five), 
                new Square(Files.b, Ranks.four));

            var moveEntries = new List<MoveEntry>() {
                SimpleMoveEntry(
                    new Square(Files.b, Ranks.five), 
                    new Square(Files.b, Ranks.four), 
                    board)};

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.five)]
                .EnPassant(board.Position, moveEntries));

            moveEntries.Add(
                SimpleMoveEntry(
                    new Square(Files.a, Ranks.four), 
                    new Square(Files.a, Ranks.five), 
                    board));

            Assert.Empty(
                board.Position[new Square(Files.b, Ranks.four)]
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantNoRushForward()
        {
            var board = BoardPawnSetup(
                new Square(Files.a, Ranks.five), 
                new Square(Files.b, Ranks.five),
                BoardPawnSetup(
                    new Square(Files.g, Ranks.four), 
                    new Square(Files.h, Ranks.four)    
                ));

            var moveEntries = new List<MoveEntry>() {
                SimpleMoveEntry(
                    new Square(Files.b, Ranks.six), 
                    new Square(Files.b, Ranks.five), 
                    board)};

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.five)]
                .EnPassant(board.Position, moveEntries));
            
            moveEntries.Add(
                SimpleMoveEntry(
                    new Square(Files.g, Ranks.three), 
                    new Square(Files.g, Ranks.four), 
                    board));

            Assert.Empty(
                board.Position[new Square(Files.h, Ranks.four)]
                .EnPassant(board.Position, moveEntries));
        }

        [Fact]
        public void TestEnPassantAvailable()
        {
            var board = BoardPawnSetup(
                new Square(Files.a, Ranks.five), 
                new Square(Files.b, Ranks.five),
                BoardPawnSetup(
                    new Square(Files.g, Ranks.four), 
                    new Square(Files.h, Ranks.four)    
                ));

            var moveEntries = new List<MoveEntry>() {
                SimpleMoveEntry(
                    new Square(Files.b, Ranks.seven), 
                    new Square(Files.b, Ranks.five), 
                    board)};

            var passant1 = board.Position[new Square(Files.a, Ranks.five)]
                .EnPassant(board.Position, moveEntries);

            Assert.Equal(new Square(Files.a, Ranks.five), passant1.First().FromSquare);
            Assert.Equal(new Square(Files.b, Ranks.six), passant1.First().ToSquare);

            moveEntries.Add(
                SimpleMoveEntry(
                    new Square(Files.g, Ranks.two), 
                    new Square(Files.g, Ranks.four), 
                    board));

            var passant2 = board.Position[new Square(Files.h, Ranks.four)]
                .EnPassant(board.Position, moveEntries);

            Assert.Equal(new Square(Files.h, Ranks.four), passant2.First().FromSquare);
            Assert.Equal(new Square(Files.g, Ranks.three), passant2.First().ToSquare);

            Assert.All(new []{passant1, passant2}, (ep) =>{
                Assert.Single(ep);    
                Assert.Equal(MoveType.Passant, ep.First().Type);
            });

        }    

        private Board BoardPawnSetup(Square sw, Square sb, Board board = null)
        {
            var newBoard = (board is null) ? new Board() : board;

            newBoard.AddPiece<Pawn>(sw, true);
            newBoard.AddPiece<Pawn>(sb, false);           

            return newBoard; 
        }

        private MoveEntry SimpleMoveEntry(Square to, Square from, Board board) =>
            new MoveEntry(new Move(to, from, MoveType.Normal), board.Position);
    }
}