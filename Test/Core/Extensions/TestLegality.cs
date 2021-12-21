using System.Collections.Generic;
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

            Assert.True(whiteIsChecked == chess.IsChecked(true));
            Assert.True(blackIsChecked == chess.IsChecked(false));
        }

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