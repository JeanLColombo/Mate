using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements;
using Mate.Core.Elements.Pieces;
using Mate.Core.Extensions;
using Mate.Tests.Core.Mocks;


namespace Mate.Tests.Core.Elements.Pieces
{
    public class TestKing
    {
        [Fact]
        public void TestKingOfTheHill()
        {
            var board = new Board();

            board.AddPiece<King>(SquareEFive, true);
            
            board.AddPiece<MockedPiece>(new Square(Files.e, Ranks.six), true);
            board.AddPiece<MockedPiece>(new Square(Files.f, Ranks.six), false);
            board.AddPiece<MockedPiece>(new Square(Files.g, Ranks.five), true);
            board.AddPiece<MockedPiece>(new Square(Files.f, Ranks.four), false);
            board.AddPiece<MockedPiece>(new Square(Files.e, Ranks.two), true);
            board.AddPiece<MockedPiece>(new Square(Files.a, Ranks.one), false);
            board.AddPiece<MockedPiece>(new Square(Files.d, Ranks.five), true);
            board.AddPiece<MockedPiece>(new Square(Files.b, Ranks.eight), false);

            var moves = board.Position[SquareEFive].AvailableMoves(board.Position);

            Assert.Equal(6, moves.Count);
            Assert.Equal(4, moves.Where(m => m.Type is MoveType.Normal).ToList().Count());
            Assert.Equal(2, moves.Where(m => m.Type is MoveType.Capture).ToList().Count());
            Assert.All(moves.Select(m => m.FromSquare), (s) => Assert.Equal(SquareEFive, s));

            Assert.All(new Square[] 
                {
                    new Square(Files.f, Ranks.six), 
                    new Square(Files.f, Ranks.four)
                }, (s) => 
                Assert.Contains(
                    s, 
                    moves
                        .Where(m => m.Type is MoveType.Capture)
                        .Select(m => m.ToSquare)
                        .ToList()));
        }

        private Square SquareEFive => new Square(Files.e, Ranks.five);
    }
}