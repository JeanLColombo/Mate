using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements.Pieces;
using Core.Elements.Rules;
using Core.Extensions;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions
{
    public class TestLegality
    {
        [Theory]
        [MemberData(nameof(BoardPositions))]
        public void TestIsChecked(
            IReadOnlyDictionary<Square,IPiece> position,
            bool whiteIsChecked,
            bool blackIsChecked
        )
        {
            IChess chess = new Custom(position);

            Assert.True(whiteIsChecked == chess.IsChecked<Custom>(true));
            Assert.True(blackIsChecked == chess.IsChecked<Custom>(false));
        }

        [Theory]
        [MemberData(nameof(LegalData))]
        public void TestIsLegal(
            Move prepareMove,
            Move move,
            bool isLegal
        )
        {
            IChess chess = new Custom(CustomPosition);
            
            if (!(prepareMove is null))
                chess.Process(prepareMove, out IPiece p);

            Assert.Equal(isLegal, chess.IsLegal<Custom>(move));

            Assert.Equal((prepareMove is null ? 0 : 1), chess.MoveEntries.Count);
        }

        [Fact]
        public void TestLegalityOnWrongRules()
        {
            IChess chess = new Custom(CustomPosition);

            var move = LegalData.Select(ld => (Move)ld.ToList().ElementAt(1)).ToList().First();

            Assert.Throws<ArgumentException>(() => chess.IsLegal<MockedChess>(move));
        }

        private IReadOnlyDictionary<Square, IPiece> CustomPosition =>
            new Dictionary<Square, IPiece>() {
                {new Square(Files.a, Ranks.one  ), new Rook(    true    )},
                {new Square(Files.c, Ranks.two  ), new Pawn(    false   )},
                {new Square(Files.c, Ranks.three), new Bishop(  false   )},
                {new Square(Files.c, Ranks.seven), new Pawn(    false   )},
                {new Square(Files.d, Ranks.two  ), new Pawn(    true    )},
                {new Square(Files.d, Ranks.five ), new Pawn(    true    )},
                {new Square(Files.e, Ranks.one  ), new King(    true    )},
                {new Square(Files.e, Ranks.four ), new Queen(   true    )},
                {new Square(Files.e, Ranks.eight), new Rook(    false   )},
                {new Square(Files.f, Ranks.three), new Rook(    true    )},
                {new Square(Files.f, Ranks.four ), new Pawn(    false   )},
                {new Square(Files.f, Ranks.seven), new King(    false   )},
                {new Square(Files.f, Ranks.eight), new Bishop(  true    )},
                {new Square(Files.g, Ranks.two  ), new Pawn(    true    )},
                {new Square(Files.g, Ranks.seven), new Pawn(    true    )},
                {new Square(Files.h, Ranks.one  ), new Rook(    true    )},
                {new Square(Files.h, Ranks.eight), new King(    true    )}
            };

        public static IEnumerable<object[]> LegalData => new[] {
            new object[] {
                null,
                new Move(
                    new Square(Files.c, Ranks.two),
                    new Square(Files.c, Ranks.one),
                    MoveType.PromoteToBishop),
                true
            },
            new object[] {
                new Move(
                    new Square(Files.c, Ranks.seven),
                    new Square(Files.c, Ranks.five),
                    MoveType.Rush),
                new Move(
                    new Square(Files.d, Ranks.five),
                    new Square(Files.c, Ranks.six),
                    MoveType.Passant),
                true
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.d, Ranks.two),
                    new Square(Files.d, Ranks.four),
                    MoveType.Rush),
                false
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.e, Ranks.one),
                    new Square(Files.c, Ranks.one),
                    MoveType.Castle),
                false
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.e, Ranks.one),
                    new Square(Files.g, Ranks.one),
                    MoveType.Castle),
                true
            },
            new object[] {
                new Move(
                    new Square(Files.c, Ranks.three),
                    new Square(Files.d, Ranks.two),
                    MoveType.Capture
                ),
                new Move(
                    new Square(Files.e, Ranks.one),
                    new Square(Files.g, Ranks.one),
                    MoveType.Castle),
                false
            },
            new object[] {
                new Move(
                    new Square(Files.c, Ranks.three),
                    new Square(Files.d, Ranks.four),
                    MoveType.Normal
                ),
                new Move(
                    new Square(Files.e, Ranks.one),
                    new Square(Files.g, Ranks.one),
                    MoveType.Castle),
                false
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.e, Ranks.one),
                    new Square(Files.f, Ranks.two),
                    MoveType.Normal),
                true
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.e, Ranks.four),
                    new Square(Files.d, Ranks.four),
                    MoveType.Normal),
                false
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.e, Ranks.four),
                    new Square(Files.e, Ranks.eight),
                    MoveType.Capture),
                true
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.e, Ranks.four),
                    new Square(Files.f, Ranks.four),
                    MoveType.Capture),
                false
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.g, Ranks.two),
                    new Square(Files.g, Ranks.four),
                    MoveType.Rush),
                true
            },
            new object[] {
                new Move(
                    new Square(Files.g, Ranks.two),
                    new Square(Files.g, Ranks.four),
                    MoveType.Rush),
                new Move(
                    new Square(Files.f, Ranks.four),
                    new Square(Files.g, Ranks.three),
                    MoveType.Passant),
                false
            },
            new object[] {
                null,
                new Move(
                    new Square(Files.g, Ranks.seven),
                    new Square(Files.g, Ranks.eight),
                    MoveType.PromoteToQueen),
                false
            },
         };

        public static IEnumerable<object[]> BoardPositions => new []{
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.a, Ranks.one  ), new MockedPiece(true)},
                    {new Square(Files.b, Ranks.two  ), new MockedPiece(false)},
                    {new Square(Files.c, Ranks.three), new MockedPiece(true)},
                    {new Square(Files.d, Ranks.four ), new MockedPiece(false)},
                    {new Square(Files.e, Ranks.five ), new MockedPiece(true)},
                    {new Square(Files.f, Ranks.six  ), new MockedPiece(false)},
                    {new Square(Files.g, Ranks.seven), new MockedPiece(true)},
                    {new Square(Files.h, Ranks.eight), new MockedPiece(false)},
                },
                false,
                false
            },
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.a, Ranks.one  ), new King(true)},
                    {new Square(Files.b, Ranks.one  ), new Queen(true)},
                    {new Square(Files.c, Ranks.one  ), new Rook(true)},
                    {new Square(Files.d, Ranks.one  ), new Knight(true)},
                    {new Square(Files.e, Ranks.eight), new Bishop(false)},
                    {new Square(Files.f, Ranks.eight), new Rook(false)},
                    {new Square(Files.g, Ranks.eight), new Queen(false)},
                    {new Square(Files.h, Ranks.eight), new King(false)},
                },
                false,
                false
            },
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.a, Ranks.one  ), new Queen(true)},
                    {new Square(Files.b, Ranks.one  ), new King(true)},
                    {new Square(Files.c, Ranks.one  ), new Rook(true)},
                    {new Square(Files.d, Ranks.one  ), new Knight(true)},
                    {new Square(Files.e, Ranks.eight), new Bishop(false)},
                    {new Square(Files.f, Ranks.eight), new Rook(false)},
                    {new Square(Files.g, Ranks.eight), new Queen(false)},
                    {new Square(Files.h, Ranks.eight), new King(false)},
                },
                false,
                true
            },
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.a, Ranks.one  ), new King(true)},
                    {new Square(Files.b, Ranks.one  ), new Queen(true)},
                    {new Square(Files.c, Ranks.one  ), new Rook(true)},
                    {new Square(Files.d, Ranks.one  ), new Knight(true)},
                    {new Square(Files.e, Ranks.eight), new Bishop(false)},
                    {new Square(Files.f, Ranks.eight), new Rook(false)},
                    {new Square(Files.g, Ranks.eight), new King(true)},
                    {new Square(Files.h, Ranks.eight), new Queen(false)},
                },
                true,
                false
            },
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.e,    Ranks.three),   new King(true)},
                    {new Square(Files.e,    Ranks.six),     new King(false)},
                    {new Square(Files.d,    Ranks.five),    new Pawn(true)},
                    {new Square(Files.e,    Ranks.five),    new Pawn(true)},
                    {new Square(Files.f,    Ranks.five),    new Pawn(true)},
                    {new Square(Files.d,    Ranks.four),    new Pawn(false)},
                    {new Square(Files.e,    Ranks.four),    new Pawn(false)},
                    {new Square(Files.f,    Ranks.four),    new Pawn(false)},
                },
                true,
                true
            },
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.a,    Ranks.eight),   new Queen(true)},
                    {new Square(Files.b,    Ranks.seven),   new Pawn(true)},
                    {new Square(Files.d,    Ranks.six),     new Knight(true)},
                    {new Square(Files.e,    Ranks.six),     new Bishop(true)},
                    {new Square(Files.h,    Ranks.eight),   new Rook(true)},
                    {new Square(Files.c,    Ranks.eight),   new King(false)}
                },
                false,
                true
            },
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.c,    Ranks.six),     new King(false)},
                    {new Square(Files.d,    Ranks.five),    new King(true)}
                },
                true,
                true
            },
            new object[] {
                new Dictionary<Square, IPiece>(){
                    {new Square(Files.b,    Ranks.four),    new King(false)},
                    {new Square(Files.d,    Ranks.seven),   new King(false)},
                    {new Square(Files.f,    Ranks.five),    new Knight(false)},
                    {new Square(Files.e,    Ranks.three),   new King(true)},
                    {new Square(Files.e,    Ranks.seven),   new King(true)}
                },
                true,
                true
            }
        };
    }
}