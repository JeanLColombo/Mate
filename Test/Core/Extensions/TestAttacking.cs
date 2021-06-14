using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions
{
    public class TestAttacking
    {
        [Fact]
        public void TestAttackOnEmptySquare()
        {
            var piece = new MockedPiece(true);

            var m = piece.AttackSquare(
                new Square(Files.a, Ranks.two), 
                CreatePositionA(piece));

            Assert.Equal(new Square(Files.a, Ranks.one), m.FromSquare);
            Assert.Equal(new Square(Files.a, Ranks.two), m.ToSquare);
            Assert.Equal(MoveType.Normal, m.Type);
        }

        [Fact]
        public void TestAttackOnSquareOcuppiedByOppositeColor()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                new Square(Files.b, Ranks.two), 
                CreatePositionA(piece));

            Assert.Equal(new Square(Files.a, Ranks.one), m.FromSquare);
            Assert.Equal(new Square(Files.b, Ranks.two), m.ToSquare);
            Assert.Equal(MoveType.Capture, m.Type);
        }

        [Fact]
        public void TestAttackOnSquareOccupiedBySameColor()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                new Square(Files.b, Ranks.one), 
                CreatePositionA(piece));

            Assert.Null(m);
        }

        [Fact]
        public void TestAttackFromOffThePosition()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                new Square(Files.a, Ranks.two), 
                CreatePositionA());

            Assert.Null(m);
        }

        [Fact]
        public void TestAttackNoSquares()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.AttackSquare(
                null, 
                CreatePositionA(piece));

            Assert.Null(m);
        }

        [Fact]
        public void TestAttackThroughEmptyFiles()
        {
            var pos = CreatePositionB();

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.Files, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(3, moves.Count);
            Assert.Contains(new Square(Files.f, Ranks.four), toSquares);  
            Assert.Contains(new Square(Files.g, Ranks.four), toSquares);
            Assert.Contains(new Square(Files.h, Ranks.four), toSquares); 

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));     
        }

        [Fact]
        public void TestAttackThroughOccupiedFiles()
        {
            var pos = CreatePositionB(new Square(Files.h, Ranks.four));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.Files, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(2, moves.Count);
            Assert.Contains(new Square(Files.f, Ranks.four), toSquares);  
            Assert.Contains(new Square(Files.g, Ranks.four), toSquares);     
        }

        [Fact]
        public void TestAttackThroughEnemyFiles()
        {
            var pos = CreatePositionB(SquareEFour, new Square(Files.a, Ranks.four));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.Files, false, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(4, moves.Count);
            Assert.Contains(new Square(Files.a, Ranks.four), toSquares);  
            Assert.Contains(new Square(Files.b, Ranks.four), toSquares);    
            Assert.Contains(new Square(Files.c, Ranks.four), toSquares);  
            Assert.Contains(new Square(Files.d, Ranks.four), toSquares); 

            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));
            Assert.Single(moves.Where(m => m.Type == MoveType.Capture).ToList());
        }

        [Fact]
        public void TestAttackThroughEmptyRanks()
        {
            var pos = CreatePositionB();

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.Ranks, false, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(3, moves.Count);
            Assert.Contains(new Square(Files.e, Ranks.one), toSquares);  
            Assert.Contains(new Square(Files.e, Ranks.two), toSquares);
            Assert.Contains(new Square(Files.e, Ranks.three), toSquares); 

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));     
        }

        [Fact]
        public void TestAttackThroughOccupiedRanks()
        {
            var pos = CreatePositionB(new Square(Files.e, Ranks.seven));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.Ranks, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(2, moves.Count);
            Assert.Contains(new Square(Files.e, Ranks.five), toSquares);  
            Assert.Contains(new Square(Files.e, Ranks.six), toSquares);     
        }

        [Fact]
        public void TestAttackThroughEnemyRanks()
        {
            var pos = CreatePositionB(SquareEFour, new Square(Files.e, Ranks.eight));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.Ranks, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(4, moves.Count);
            Assert.Contains(new Square(Files.e, Ranks.five), toSquares);  
            Assert.Contains(new Square(Files.e, Ranks.six), toSquares);    
            Assert.Contains(new Square(Files.e, Ranks.seven), toSquares);  
            Assert.Contains(new Square(Files.e, Ranks.eight), toSquares); 

            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));
            Assert.Single(moves.Where(m => m.Type == MoveType.Capture).ToList());
        }

        [Fact]
        public void TestAttackThroughEmptyMainDiagonal()
        {
            var pos = CreatePositionB();

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.MainDiagonal, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(3, moves.Count);
            Assert.Contains(new Square(Files.f, Ranks.five), toSquares);  
            Assert.Contains(new Square(Files.g, Ranks.six), toSquares);
            Assert.Contains(new Square(Files.h, Ranks.seven), toSquares); 

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));     
        }

        [Fact]
        public void TestAttackThroughOccupiedMainDiagonal()
        {
            var pos = CreatePositionB(new Square(Files.f, Ranks.five));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.MainDiagonal, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Empty(moves); 
        }

        [Fact]
        public void TestAttackThroughEnemyMainDiagonal()
        {
            var pos = CreatePositionB(SquareEFour, new Square(Files.d, Ranks.three));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.MainDiagonal, false, pos);
            
            Move m = moves.First();
            
            Assert.Single(moves);
            Assert.Equal(new Square(Files.d, Ranks.three), m.ToSquare);  
            Assert.Equal(SquareEFour, m.FromSquare);    
            Assert.Equal(MoveType.Capture, m.Type);
        }

        [Fact]
        public void TestAttackThroughEmptyOppositeDiagonal()
        {
            var pos = CreatePositionB();

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.OppositeDiagonal, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(4, moves.Count);
            Assert.Contains(new Square(Files.d, Ranks.five), toSquares);  
            Assert.Contains(new Square(Files.c, Ranks.six), toSquares);
            Assert.Contains(new Square(Files.b, Ranks.seven), toSquares); 
            Assert.Contains(new Square(Files.a, Ranks.eight), toSquares);

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare));     
        }

        [Fact]
        public void TestAttackThroughOcuppiedOppositeDiagonal()
        {
            var pos = CreatePositionB(new Square(Files.a, Ranks.eight));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.OppositeDiagonal, true, pos);
            
            var toSquares = moves.Select(m => m.ToSquare).ToList();

            Assert.Equal(3, moves.Count);
            Assert.Contains(new Square(Files.d, Ranks.five), toSquares);  
            Assert.Contains(new Square(Files.c, Ranks.six), toSquares);
            Assert.Contains(new Square(Files.b, Ranks.seven), toSquares); 

            Assert.All(moves, m => Assert.Equal(MoveType.Normal, m.Type));
            Assert.All(moves, m => Assert.Equal(SquareEFour, m.FromSquare)); 
        }

        [Fact]
        public void TestAttackThroughEnemyOppositeDiagonal()
        {
            var pos = CreatePositionB(SquareEFour, new Square(Files.f, Ranks.three));

            var moves = ((Piece)pos[SquareEFour]).Attack(Through.OppositeDiagonal, false, pos);
            
            Move m = moves.First();
            
            Assert.Single(moves);
            Assert.Equal(new Square(Files.f, Ranks.three), m.ToSquare);  
            Assert.Equal(SquareEFour, m.FromSquare);    
            Assert.Equal(MoveType.Capture, m.Type);
        }

        [Fact]
        public void TestAttackThroughFromOffThePosition()
        {
            var piece = new MockedPiece(true);
            
            var m = piece.Attack(
                Through.Files, 
                true,
                CreatePositionA());

            Assert.Empty(m);
        }

        private Square SquareEFour => new Square(Files.e, Ranks.four);

        private IReadOnlyDictionary<Square,IPiece> CreatePositionA(
            IPiece p = null) 
        {
            var position = new Dictionary<Square,IPiece>() { 
                {new Square(Files.b, Ranks.one), new MockedPiece(true)},
                {new Square(Files.b, Ranks.two), new MockedPiece(false)}};

            if (p is not null) position[new Square(Files.a, Ranks.one)] = p;

            return position;
        }

        private IReadOnlyDictionary<Square, IPiece> CreatePositionB(
            Square sWhite = null,
            Square sBlack = null)
        {
            var position = new Dictionary<Square,IPiece>() {
                {SquareEFour, new MockedPiece(true)}};
            
            if (sWhite is not null) position[sWhite] = new MockedPiece(true); 
            if (sBlack is not null) position[sBlack] = new MockedPiece(false);

            return position;
        }
    }
}