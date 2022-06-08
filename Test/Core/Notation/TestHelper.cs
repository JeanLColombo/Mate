using System.Collections.Generic;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Pieces;
using Mate.Core.Notation;

namespace Mate.Tests.Core.Notation
{
    public class TestHelper
    {
        [Theory]
        [InlineData("a1", Files.a, Ranks.one)]
        [InlineData("b1", Files.b, Ranks.one)]
        [InlineData("a2", Files.a, Ranks.two)]
        [InlineData("c3", Files.c, Ranks.three)]
        [InlineData("h8", Files.h, Ranks.eight)]
        public void TestSquareToNotation(string squareNotation, Files file, Ranks rank) =>
            Assert.Equal(squareNotation, Helper.SquareToNotation(new Square(file, rank)));
        
        [Theory]
        [MemberData(nameof(PieceData))]
        public void TestPieceToNotation(IPiece piece, string notation) =>
            Assert.Equal(notation, Helper.PieceToNotation(piece));

        [Theory]
        [MemberData(nameof(MoveData))]
        public void TestMoveToNotation(Move move, string notation) =>
            Assert.Equal(notation, Helper.MoveToNotation(move));

        public static IEnumerable<object[]> PieceData => new[]{
            new object[] {
                new Pawn(true),
                ""},
            new object[] {
                new King(true),
                "K"},
            new object[] {
                new Queen(true),
                "Q"},
            new object[] {
                new Bishop(true),
                "B"},
            new object[] {
                new Knight(true),
                "N"},
            new object[] {
                new Rook(true),
                "R"}};

        public static IEnumerable<object[]> MoveData => new[]{
            new object[]{new Move(new Square(Files.e, Ranks.one),   new Square(Files.g, Ranks.one),     MoveType.Castle),           "0-0"},
            new object[]{new Move(new Square(Files.e, Ranks.eight), new Square(Files.c, Ranks.eight),   MoveType.Castle),           "0-0-0"},
            new object[]{new Move(new Square(Files.b, Ranks.two),   new Square(Files.b, Ranks.three),   MoveType.Normal),           "b3"},
            new object[]{new Move(new Square(Files.b, Ranks.two),   new Square(Files.b, Ranks.four),    MoveType.Rush),             "b4"},
            new object[]{new Move(new Square(Files.b, Ranks.five),  new Square(Files.c, Ranks.six),     MoveType.Passant),          "xc6"},
            new object[]{new Move(new Square(Files.b, Ranks.five),  new Square(Files.c, Ranks.six),     MoveType.Capture),          "xc6"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.b, Ranks.eight),  MoveType.PromoteToBishop),  "b8=B"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.b, Ranks.eight),  MoveType.PromoteToKnight),  "b8=N"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.b, Ranks.eight),  MoveType.PromoteToQueen),   "b8=Q"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.b, Ranks.eight),  MoveType.PromoteToRook),    "b8=R"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.a, Ranks.eight),  MoveType.PromoteToBishop),  "xa8=B"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.a, Ranks.eight),  MoveType.PromoteToKnight),  "xa8=N"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.c, Ranks.eight),  MoveType.PromoteToQueen),   "xc8=Q"},
            new object[]{new Move(new Square(Files.b, Ranks.seven),  new Square(Files.c, Ranks.eight),  MoveType.PromoteToRook),    "xc8=R"}
        };
    }

}