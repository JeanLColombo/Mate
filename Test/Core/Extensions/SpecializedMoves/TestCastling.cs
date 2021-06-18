using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;
using Core.Extensions.SpecializedMoves;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions
{
    public class TestCastling
    {
        [Fact]
        public void TestCastlingNotOnKing() => 
            Assert.Empty(
                new MockedPiece(true)
                .Castles(
                    new Board().Position, 
                    new List<MoveEntry>()));

        [Fact]
        public void TestCastlingFromOffTheBoard() =>
            Assert.Empty(
                new King(true)
                .Castles(
                    new Board().Position,
                    new List<MoveEntry>()));

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestCastingFromOffTheRanks(bool color)
        {
            var board = SetupKingAndRooks(new Square(Files.a, Ranks.five), color);

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.five)]
                .Castles(board.Position, new List<MoveEntry>()));
        }

        [Fact]
        public void TestCastlingWhenKingMoved()
        {
            var board = SetupKingAndRooks(new Square(Files.a, Ranks.one), true);   

            Assert.Empty(
                board.Position[new Square(Files.a, Ranks.one)]
                .Castles(board.Position, 
                new List<MoveEntry>(){
                    new MoveEntry(new Move(
                        new Square(Files.a, Ranks.two),
                        new Square(Files.a, Ranks.one), 
                        MoveType.Normal), board.Position)}));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestCastlingWhenNoRooks(bool color)
        {
            var board = SetupKingAndRooks(
                new Square(Files.a, (color ? Ranks.one : Ranks.eight)), color);   

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.two), color);   
            board.AddPiece<MockedPiece>(new Square(Files.d, Ranks.three), !color);

            Assert.Empty(
                board.Position[new Square(Files.a, (color ? Ranks.one : Ranks.eight))]
                .Castles(board.Position, new List<MoveEntry>()));
        }   

        [Fact]
        public void TestCastlingWhenRookHasMoved()
        {
            var board = SetupKingAndRooks(
                new Square(Files.e, Ranks.one), true,
                new Square(Files.a, Ranks.one));   

            Assert.Empty(
                board.Position[new Square(Files.e, Ranks.one)]
                .Castles(board.Position, 
                new List<MoveEntry>(){
                    new MoveEntry(new Move(
                        new Square(Files.a, Ranks.two),
                        new Square(Files.a, Ranks.one), 
                        MoveType.Normal), board.Position)}));            
        }

        [Fact]
        public void TestCastlingThroughOccupiedSquares()
        {
            var board = SetupKingAndRooks(
                new Square(Files.e, Ranks.one), true,
                new Square(Files.a, Ranks.one), 
                new Square(Files.h, Ranks.one)); 

            board.AddPiece<MockedPiece>(new Square(Files.b, Ranks.one), true); 
            board.AddPiece<MockedPiece>(new Square(Files.f, Ranks.one), true); 

            Assert.Empty(
                board.Position[new Square(Files.e, Ranks.one)]
                .Castles(board.Position, new List<MoveEntry>()));
        }    

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestQueenSideCastles(bool color)
        {
            var board = SetupKingAndRooks(
                new Square(Files.e, (color ? Ranks.one : Ranks.eight)), 
                color,
                new Square(Files.a, (color ? Ranks.one : Ranks.eight)));     

            var moves =  board.Position[new Square(
                    Files.e, (color ? Ranks.one : Ranks.eight))]
                .Castles(board.Position, new List<MoveEntry>());

            Assert.Single(moves);

            Assert.True(
                new Square(Files.e, (color ? Ranks.one : Ranks.eight))
                .IsSameSquareAs(moves.First().FromSquare));

            Assert.True(
                new Square(Files.c, (color ? Ranks.one : Ranks.eight))
                .IsSameSquareAs(moves.First().ToSquare));

            Assert.Equal(MoveType.Castle, moves.First().Type);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestKingSideCastles(bool color)
        {
            var board = SetupKingAndRooks(
                new Square(Files.e, (color ? Ranks.one : Ranks.eight)), 
                color,
                new Square(Files.h, (color ? Ranks.one : Ranks.eight)));     

            var moves =  board.Position[new Square(
                    Files.e, (color ? Ranks.one : Ranks.eight))]
                .Castles(board.Position, new List<MoveEntry>());

            Assert.Single(moves);

            Assert.True(
                new Square(Files.e, (color ? Ranks.one : Ranks.eight))
                .IsSameSquareAs(moves.First().FromSquare));

            Assert.True(
                new Square(Files.g, (color ? Ranks.one : Ranks.eight))
                .IsSameSquareAs(moves.First().ToSquare));

            Assert.Equal(MoveType.Castle, moves.First().Type);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestCastles(bool color)
        {
            var rankByColor = (color ? Ranks.one : Ranks.eight);

            var board = SetupKingAndRooks(
                new Square(Files.e, rankByColor), color,
                new Square(Files.a, rankByColor), 
                new Square(Files.h, rankByColor)); 

            var moves =  board.Position[new Square(Files.e, rankByColor)]
                .Castles(board.Position, new List<MoveEntry>());

            Assert.Equal(2, moves.Count);
            
            moves.All(m => {
                Assert.Equal(MoveType.Castle, m.Type);
                Assert.True(m.FromSquare
                    .IsSameSquareAs(new Square(Files.e, rankByColor)));
                return true;});
        }

        private Board SetupKingAndRooks(
            Square ks, 
            bool color, 
            Square r1 = null, 
            Square r2 = null)
        {
            var board = new Board();

            board.AddPiece<King>(ks, color);

            if (r1 is not null) board.AddPiece<Rook>(r1, color);
            if (r2 is not null) board.AddPiece<Rook>(r2, color);

            return board;
        }
    }
}