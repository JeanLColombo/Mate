using System;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements;
using Mate.Core.Extensions;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Abstractions
{
    public class TestRoyalty
    {
        [Fact]
        public void TestRoyaltyOnTheCenter()
        {
            var board = new Board();

            board.AddPiece<MockedRoyalPiece>(SquareEFive, true);

            var royal = (MockedRoyalPiece)board.Position[SquareEFive];

            var moves = royal.GetRoyalAttack(board.Position, 7);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(27, moves.Count);
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.e)
                .Select(f => new Square(f , Ranks.five)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enum.GetValues(typeof(Ranks)).Cast<Ranks>()
                .Where(r => r is not Ranks.five)
                .Select(r => new Square(Files.e , r)).ToList(), 
                s => Assert.Contains(s, toSquares));
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.e)
                .Select(i => new Square((Files)i , (Ranks)i)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enumerable.Range(-4,8)
                .Where(i => i !=0)
                .Select(i => SquareEFive.Maneuver(Through.OppositeDiagonal, i))
                .Where(s => s is not null)
                .ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFive, m.FromSquare));   
        }
    
        [Fact]
        public void TestRoyaltyOnTheCorner()
        {
            var board = new Board();

            board.AddPiece<MockedRoyalPiece>(SquareAOne, true);

            var royal = (MockedRoyalPiece)board.Position[SquareAOne];

            var moves = royal.GetRoyalAttack(board.Position, 3);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(9, moves.Count);
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.a)
                .Where(f => (int)f < 5 )
                .Select(f => new Square(f , Ranks.one)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enum.GetValues(typeof(Ranks)).Cast<Ranks>()
                .Where(r => r is not Ranks.one)
                .Where(r => (int)r < 5 )
                .Select(r => new Square(Files.a , r)).ToList(), 
                s => Assert.Contains(s, toSquares));
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.a)
                .Where(i => i < 5)
                .Select(i => new Square((Files)i , (Ranks)i)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareAOne, m.FromSquare)); 
        }
    
        [Fact]
        public void TestRoyaltyIsBlocked()
        {
            var board = new Board();

            board.AddPiece<MockedRoyalPiece>(SquareAOne, true);
            board.AddPiece<MockedPiece>(new Square(Files.c, Ranks.three), true);

            var royal = (MockedRoyalPiece)board.Position[SquareAOne];

            var moves = royal.GetRoyalAttack(board.Position, 2);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(5, moves.Count);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.a)
                .Where(f => (int)f < 4 )
                .Select(f => new Square(f , Ranks.one)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enum.GetValues(typeof(Ranks)).Cast<Ranks>()
                .Where(r => r is not Ranks.one)
                .Where(r => (int)r < 4 )
                .Select(r => new Square(Files.a , r)).ToList(), 
                s => Assert.Contains(s, toSquares));
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.a)
                .Where(i => i < 3)
                .Select(i => new Square((Files)i , (Ranks)i)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareAOne, m.FromSquare));   
        }

        [Fact]
        public void TestRoyalAttack()
        {
            var board = new Board();

            board.AddPiece<MockedRoyalPiece>(SquareAOne, true);
            board.AddPiece<MockedPiece>(new Square(Files.c, Ranks.three), false);

            var royal = (MockedRoyalPiece)board.Position[SquareAOne];

            var moves = royal.GetRoyalAttack(board.Position, 4);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(10, moves.Count);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<Files>()
                .Where(f => f is not Files.a)
                .Where(f => (int)f < 6 )
                .Select(f => new Square(f , Ranks.one)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enum.GetValues(typeof(Ranks)).Cast<Ranks>()
                .Where(r => r is not Ranks.one)
                .Where(r => (int)r < 6 )
                .Select(r => new Square(Files.a , r)).ToList(), 
                s => Assert.Contains(s, toSquares));
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.a)
                .Where(i => i < 4)
                .Select(i => new Square((Files)i , (Ranks)i)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(SquareAOne, m.FromSquare));   

            Assert.Single(moves.Where(m => m.Type == MoveType.Capture).ToList());
            Assert.Equal(new Square(Files.c, Ranks.three), 
                moves.Where(m => m.Type == MoveType.Capture).Select(m => m.ToSquare).ToList().First());
        }

        private Square SquareAOne => new Square(Files.a, Ranks.one);
        private Square SquareEFive => new Square(Files.e, Ranks.five);
    }
}