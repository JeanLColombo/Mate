using System;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Elements.Pieces
{
    public class TestRook
    {
        [Fact]
        public void TestRookOnTheCenter()
        {
            var board = new Board();

            board.AddPiece<Rook>(SquareEFour, true);

            var moves = board.Position[SquareEFour].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(14, moves.Count);
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.e)
                .Select(f => new Square(f , Ranks.four)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enum.GetValues(typeof(Ranks)).Cast<Ranks>()
                .Where(r => r is not Ranks.four)
                .Select(r => new Square(Files.e , r)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));
        }

        [Fact]
        public void TestRookOnTheCorner()
        {
            var board = new Board();

            board.AddPiece<Rook>(SquareAOne, true);

            var moves = board.Position[SquareAOne].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();   

            Assert.Equal(14, moves.Count);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.a)
                .Select(f => new Square(f , Ranks.one)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enum.GetValues(typeof(Ranks)).Cast<Ranks>()
                .Where(r => r is not Ranks.one)
                .Select(r => new Square(Files.a , r)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareAOne, m.FromSquare));
        }

        [Fact]
        public void TestRookIsBlocked()
        {
            var board = new Board();

            board.AddPiece<Rook>(SquareAOne, true);
            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.three), true);   

            var moves = board.Position[SquareAOne].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();   

            Assert.Equal(8, moves.Count);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.a)
                .Select(f => new Square(f , Ranks.one)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.Contains(new Square(Files.a, Ranks.two), toSquares);    

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareAOne, m.FromSquare));
        }

        [Fact]
        public void TestRookAttacks()
        {
            var board = new Board();

            board.AddPiece<Rook>(SquareAOne, true);
            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.three), false);   

            var moves = board.Position[SquareAOne].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(9, moves.Count);

             Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.a)
                .Select(f => new Square(f , Ranks.one)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.Contains(new Square(Files.a, Ranks.two), toSquares);

            Assert.Contains(new Square(Files.a, Ranks.three), toSquares);

            Assert.All(moves, m => Assert.Equal(SquareAOne, m.FromSquare));

            Assert.Single(moves.Where(m => m.Type is MoveType.Capture).ToList());

            Assert.Equal(new Square(Files.a, Ranks.three), 
                moves.Where(m => m.Type == MoveType.Capture).Select(m => m.ToSquare).ToList().First());
        }

        private Square SquareAOne => new Square(Files.a, Ranks.one);
        private Square SquareEFour => new Square(Files.e, Ranks.four);
       
    }
}