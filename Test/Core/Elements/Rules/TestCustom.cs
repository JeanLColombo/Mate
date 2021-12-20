using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements.Pieces;
using Core.Elements.Rules;

namespace Test.Core.Elements.Rules
{
    public class TestCustom 
    {
        [Fact]
        public void TestDefaultConstructor()
        {
            var chess = new Custom(new Dictionary<Square, IPiece>());
            Assert.Empty(chess.Position);
            Assert.Empty(chess.BannedMoves);
            Assert.Empty(chess.Position);
            //TODO: Implement chess legality.
            //TODO: Implement Process Move.
            // Assert.All(new []{false, true}, c => Assert.Empty(chess.AvailableMoves(c)));
        }

        [Fact]
        public void TestDefaultConstructorWithPieces()
        {
            var chess = new Custom(CustomPositionA());

            Assert.NotEmpty(chess.Position);
        }

        [Theory]
        [MemberData(nameof(BannedDataA))]
        public void TestBannedList(
            List<MoveType> bannedList
        )
        {
            var chess = new Custom(new Dictionary<Square, IPiece>(), bannedList.ToHashSet());

            Assert.Equal(bannedList.ToList().Count, chess.BannedMoves.ToList().Count);

            Assert.All(
                bannedList.ToList(), 
                mt => Assert.Contains(mt, chess.BannedMoves));
        }

        [Theory]
        [MemberData(nameof(BannedDataB))]
        public void TestAllMoves(
            List<MoveType> allowedMoves,
            int whiteMoveCount,
            int blackMoveCount
        )
        {

            var banned = Enum.GetValues(typeof(MoveType)).Cast<MoveType>()
                .Where(mt => !allowedMoves.Contains(mt)).ToHashSet();

            var chess = new Custom(CustomPositionA(), banned);

            var whiteMoves = chess.AllMoves(true);
            var blackMoves = chess.AllMoves(false);

            Assert.Equal(whiteMoveCount, whiteMoves.Count());
            Assert.Equal(blackMoveCount, blackMoves.Count());

        }

        private IReadOnlyDictionary<Square, IPiece> CustomPositionA() =>
            new Dictionary<Square, IPiece>() {
                {new Square(Files.a, Ranks.one),        new Rook(true)},
                {new Square(Files.a, Ranks.seven),      new Pawn(true)},
                {new Square(Files.b, Ranks.seven),      new Pawn(false)},
                {new Square(Files.c, Ranks.five),       new Pawn(true)},
                {new Square(Files.c, Ranks.eight),      new Bishop(false)},
                {new Square(Files.d, Ranks.four),       new Queen(true)},
                {new Square(Files.d, Ranks.five),       new Queen(false)},
                {new Square(Files.d, Ranks.eight),      new Knight(false)},
                {new Square(Files.e, Ranks.one),        new King(true)},
                {new Square(Files.e, Ranks.eight),      new King(false)},
                {new Square(Files.f, Ranks.one),        new Knight(true)},
                {new Square(Files.f, Ranks.four),       new Pawn(false)},
                {new Square(Files.g, Ranks.one),        new Bishop(true)},
                {new Square(Files.g, Ranks.two),        new Pawn(true)},
                {new Square(Files.h, Ranks.two),        new Pawn(false)},
                {new Square(Files.h, Ranks.eight),      new Rook(false)}
            };

        public static IEnumerable<object[]> BannedDataA => new []{
            new object[] {
                new List<MoveType>() {
                    MoveType.Normal,
                    MoveType.Rush}
            },
            new object[] {
                new List<MoveType>() {
                    MoveType.Capture,
                    MoveType.Castle}
            },
            new object[] {
                new List<MoveType>() {
                    MoveType.Passant,
                    MoveType.Normal}
            },
            new object[] {
                new List<MoveType>() {
                    MoveType.PromoteToKnight,
                    MoveType.PromoteToQueen}
            },
            new object[] {
                new List<MoveType>() {
                    MoveType.PromoteToRook,
                    MoveType.PromotToBishop}
            }
        };

        public static IEnumerable<object[]> BannedDataB => new[]{
            new object[] {
                new List<MoveType>() {},
                0,
                0
            },
            new object[] {
                Enum.GetValues(typeof(MoveType)).Cast<MoveType>().ToList(),
                44,
                49
            },
            new object[] {
                new List<MoveType>() {MoveType.Normal},
                33,
                36 
            },
            new object[] {
                new List<MoveType>() {MoveType.Capture},
                5,
                3
            },
            new object[] {
                new List<MoveType>() {MoveType.Rush},
                1,
                1
            },
            new object[] {
                new List<MoveType>() {MoveType.Castle},
                1,
                1
            },
            new object[] {
                new List<MoveType>() {
                    MoveType.PromoteToKnight,
                    MoveType.PromoteToQueen,
                    MoveType.PromotToBishop,
                    MoveType.PromoteToRook},
                4,
                8
            }
        };
    }
}