using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Elements.Pieces
{
    public class TestPawn
    {
        [Theory]
        [MemberData(nameof(PawnDataA))]
        public void TestPawnOnTheCenter(
            bool color,
            Square pawnSquare,
            Square moveSquare
        )
        {
            var board = new Board();

            board.AddPiece<Pawn>(pawnSquare, color);

            var moves = board.Position[pawnSquare].AvailableMoves(board.Position);

            Assert.Single(moves);

            var move = moves.First();

            Assert.True(move.FromSquare.IsSameSquareAs(pawnSquare));
            Assert.True(move.ToSquare.IsSameSquareAs(moveSquare));
            Assert.Equal(MoveType.Normal, move.Type); 
        }

        [Theory]
        [MemberData(nameof(PawnDataA))]
        public void TestPawnIsBlocked(
            bool color,
            Square pawnSquare,
            Square moveSquare
        ){
            var board = new Board();
            
            board.AddPiece<Pawn>(pawnSquare, color);
            board.AddPiece<MockedPiece>(moveSquare, true);

            Assert.Empty(board.Position[pawnSquare].AvailableMoves(board.Position));
        }

        [Theory]
        [MemberData(nameof(PawnDataB))]
        public void TestPawnAttack(
            Tuple<Square, bool> pawnData,
            Tuple<Square, bool> rightMock,
            Tuple<Square, bool> centerMock,
            Tuple<Square, bool> leftMock
        ){
            var board = new Board();

            board.AddPiece<Pawn>(pawnData.Item1, pawnData.Item2);   
            
            if (rightMock is not null)
                board.AddPiece<MockedPiece>(rightMock.Item1, rightMock.Item2);
            
            if (centerMock is not null)    
                board.AddPiece<MockedPiece>(centerMock.Item1, centerMock.Item2);
            
            if (leftMock is not null)    
                board.AddPiece<MockedPiece>(leftMock.Item1, leftMock.Item2);

            var moves = board.Position[pawnData.Item1].AvailableMoves(board.Position);

            var attackedSquares = 
                new[]{rightMock, leftMock}
                .Where(d => d is not null)
                .Where(d => d.Item2 != pawnData.Item2)
                .Select(d => d.Item1)
                .ToList();

            var forwardIsEmpty = centerMock is null;

            Assert.Equal((forwardIsEmpty ? 1 : 0) + attackedSquares.Count, moves.Count);

            Assert.Equal(attackedSquares.Count, 
                moves.Where(m => m.Type is MoveType.Capture).ToList().Count);

            Assert.All(
                attackedSquares, 
                (s) => Assert.Contains(s, moves.Select(m => m.ToSquare)));

            Assert.All(
                moves,
                (m) => Assert.True(
                    pawnData.Item1.IsSameSquareAs(m.FromSquare)));
        }

        [Theory]
        [MemberData(nameof(PawnDataC))]
        public void TestPawnUpdateToPromotions(
            Tuple<Square, bool> pawnData,
            Tuple<Square, bool> mockData)
        {
            var board = new Board();

            board.AddPiece<Pawn>(pawnData.Item1, pawnData.Item2);   

            var notNullMock = mockData is not null;

            if (notNullMock)
                board.AddPiece<MockedPiece>(mockData.Item1, mockData.Item2);
            
            var moves = board.Position[pawnData.Item1].AvailableMoves(board.Position);

            Assert.Equal((notNullMock ? 2 : 1)*4, moves.Count);

            Assert.All(moves, (m) => Assert.True(m.FromSquare.IsSameSquareAs(pawnData.Item1)));

            Assert.All(moves, (m) => Assert.Equal((pawnData.Item2 ? Ranks.eight : Ranks.one), m.ToSquare.Rank));
            
            var distinctToFiles = moves.Select(m => m.ToSquare.File).Distinct().ToList();

            var distinctTypes = moves.Select(m => m.Type).Distinct().ToList();

            Assert.Equal(4, distinctTypes.Count);

            Assert.All(new MoveType[]{
                MoveType.PromoteToKnight, 
                MoveType.PromoteToBishop, 
                MoveType.PromoteToRook, 
                MoveType.PromoteToQueen}, 
                (mt) => 
                Assert.Contains(mt, distinctTypes));

            Assert.All(new MoveType[]{ 
                MoveType.Castle, 
                MoveType.Capture, 
                MoveType.Normal},
                (mt) => 
                Assert.DoesNotContain(mt, distinctTypes));

            Assert.Equal((notNullMock ? 2 : 1), distinctToFiles.Count);

            Assert.Contains(pawnData.Item1.File, distinctToFiles);    

            if (notNullMock) 
                Assert.Contains(mockData.Item1.File, distinctToFiles);  
        }

        public static IEnumerable<object[]> PawnDataA => new []{
            new object[]
            {
                true, 
                new Square(Files.e, Ranks.four), 
                new Square(Files.e, Ranks.five)
            },
            new object[]
            {
                false, 
                new Square(Files.e, Ranks.five), 
                new Square(Files.e, Ranks.four)
            }
        };

        public static IEnumerable<object[]> PawnDataB => new []{
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.three), true),
                new Tuple<Square, bool>(new Square(Files.b, Ranks.four), false),
                new Tuple<Square, bool>(new Square(Files.c, Ranks.four), true),
                new Tuple<Square, bool>(new Square(Files.d, Ranks.four), false)
            },
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.six), false),
                new Tuple<Square, bool>(new Square(Files.b, Ranks.five), true),
                new Tuple<Square, bool>(new Square(Files.c, Ranks.five), true),
                new Tuple<Square, bool>(new Square(Files.d, Ranks.five), true)
            },
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.three), true),
                new Tuple<Square, bool>(new Square(Files.b, Ranks.four), false),
                null,
                null
            },
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.three), true),
                null,
                new Tuple<Square, bool>(new Square(Files.c, Ranks.four), true),
                new Tuple<Square, bool>(new Square(Files.d, Ranks.four), false)
            }
        };

        public static IEnumerable<object[]> PawnDataC => new []{
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.seven), true),
                null
            },
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.two), false),
                new Tuple<Square, bool>(new Square(Files.b, Ranks.one), true)
            },
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.two), false),
                new Tuple<Square, bool>(new Square(Files.d, Ranks.one), true)
            },
            new object[]
            {
                new Tuple<Square, bool>(new Square(Files.c, Ranks.seven), true),
                new Tuple<Square, bool>(new Square(Files.d, Ranks.eight), false)
            },
        };
    }
}