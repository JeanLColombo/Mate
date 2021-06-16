using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements;
using Core.Elements.Pieces;
using Core.Extensions;
using Core.Extensions.SpecializedMoves;
using Tests.Core.Mocks;

namespace Tests.Core.Extensions.SpecializedMoves
{
    public class TestPawnRush
    {
        [Fact]
        public void TestPawnFirstMove()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            var movePawn1 = board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position);
            var movePawn2 = board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position);

            Assert.All(
                new []{movePawn1, movePawn2}, 
                m => 
                    {
                        Assert.Single(m);
                        Assert.Equal(MoveType.Normal, m.First().Type);
                    });
            
            Assert.True(new Square(Files.a, Ranks.two).IsSameSquareAs(movePawn1.First().FromSquare));
            Assert.True(new Square(Files.h, Ranks.seven).IsSameSquareAs(movePawn2.First().FromSquare));

            Assert.True(new Square(Files.a, Ranks.four).IsSameSquareAs(movePawn1.First().ToSquare));
            Assert.True(new Square(Files.h, Ranks.five).IsSameSquareAs(movePawn2.First().ToSquare));
        }

        [Fact]
        public void TestPawnFirstMoveNotOnPawn()
        {
            var board = new Board();

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.two), true);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstNotOnPosition()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.three), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.six), false);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.three)].PawnFirstMove(board.Position));
            Assert.Empty(board.Position[new Square(Files.h, Ranks.six)].PawnFirstMove(board.Position));
        }

        [Fact] 
        public void TestPawnFirstMovePawnIsBlocked()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.three), true);
            board.AddPiece<MockedPiece>(new Square(Files.h, Ranks.six), true);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
            Assert.Empty(board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstMoveIsOccupied()
        {
            var board = new Board();

            board.AddPiece<Pawn>(new Square(Files.a, Ranks.two), true);
            board.AddPiece<Pawn>(new Square(Files.h, Ranks.seven), false);

            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.four), true);
            board.AddPiece<MockedPiece>(new Square(Files.h, Ranks.five), true);

            Assert.Empty(board.Position[new Square(Files.a, Ranks.two)].PawnFirstMove(board.Position));
            Assert.Empty(board.Position[new Square(Files.h, Ranks.seven)].PawnFirstMove(board.Position));
        }

        [Fact]
        public void TestPawnFirstMoveWhenNotInPosition()
        {
            var board = new Board();

            var pawn = new Pawn(true);

            var v = pawn.PawnFirstMove(board.Position);
        }
    }
}