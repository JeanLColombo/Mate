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
    }

}