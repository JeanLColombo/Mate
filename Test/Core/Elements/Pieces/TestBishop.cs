using System;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements;
using Mate.Core.Elements.Pieces;
using Mate.Core.Extensions;
using Mate.Tests.Core.Mocks;

namespace Mate.Tests.Core.Elements.Pieces
{
    public class TestBishop
    {
        [Fact]
        public void TestBishopOnTheCenter()
        {
            var board = new Board();

            board.AddPiece<Bishop>(SquareEFive, true);

            var moves = board.Position[SquareEFive].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(13, moves.Count);
            
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
        public void TestBishopOnTheCorner()
        {
            var board = new Board();

            board.AddPiece<Bishop>(SquareAOne, true);

            var moves = board.Position[SquareAOne].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(7, moves.Count);
            
            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.a)
                .Select(i => new Square((Files)i , (Ranks)i)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareAOne, m.FromSquare)); 
        }

        [Fact]
        public void TestBishopIsBlocked()
        {
            var board = new Board();

            board.AddPiece<Bishop>(SquareEFive, true);
            board.AddPiece<MockedPiece>(new Square(Files.g, Ranks.seven), true);

            var moves = board.Position[SquareEFive].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(11, moves.Count);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.e && i is not (int)Files.g && i is not (int)Files.h)
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
        public void TestBishopAttack()
        {
            var board = new Board();

            board.AddPiece<Bishop>(SquareEFive, true);
            board.AddPiece<MockedPiece>(new Square(Files.g, Ranks.seven), false);

            var moves = board.Position[SquareEFive].AvailableMoves(board.Position);

            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(12, moves.Count);

            Assert.All(Enum.GetValues(typeof(Files)).Cast<int>()
                .Where(i => i is not (int)Files.e && i is not (int)Files.h)
                .Select(i => new Square((Files)i , (Ranks)i)).ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.All(Enumerable.Range(-4,8)
                .Where(i => i !=0)
                .Select(i => SquareEFive.Maneuver(Through.OppositeDiagonal, i))
                .Where(s => s is not null)
                .ToList(), 
                s => Assert.Contains(s, toSquares));

            Assert.Single(moves.Where(m => m.Type == MoveType.Capture).ToList());
            Assert.Equal(new Square(Files.g, Ranks.seven), 
                moves.Where(m => m.Type == MoveType.Capture).Select(m => m.ToSquare).ToList().First());

            Assert.All(moves, m => Assert.Equal(SquareEFive, m.FromSquare));
        }

        private Square SquareAOne => new Square(Files.a, Ranks.one);
        private Square SquareEFive => new Square(Files.e, Ranks.five);
    
    }
}
