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

            var fowardIsEmpty = centerMock is null;

            Assert.Equal((fowardIsEmpty ? 1 : 0) + attackedSquares.Count, moves.Count);

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
            new object[][]
            {
                new object[]{new Square(Files.c, Ranks.three), true},
                new object[]{new Square(Files.b, Ranks.four), false},
                new object[]{new Square(Files.c, Ranks.four), true},
                new object[]{new Square(Files.d, Ranks.four), false},
            }

        };
    }
}