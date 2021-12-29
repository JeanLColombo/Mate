using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Pieces;
using Mate.Core.Elements.Rules;

namespace Mate.Tests.Core.Elements.Rules
{
    public class TestClassical
    {
        [Fact]
        public void TestConstructor()
        {
            IChess chess = new Classical();

            Assert.Empty(chess.MoveEntries);
            Assert.Equal(32, chess.Position.Count);
            Assert.Equal(16, chess.Position.Values.Where(p => p.Color).ToList().Count);
            Assert.Equal(20, chess.AvailableMoves(true).Count);
            Assert.Equal(20, chess.AvailableMoves(false).Count);

            var pawns = chess.Position.Where(kp => kp.Value is Pawn).ToList();
            var knights = chess.Position.Where(kp => kp.Value is Knight).ToList();
            var bishops = chess.Position.Where(kp => kp.Value is Bishop).ToList();
            var rooks = chess.Position.Where(kp => kp.Value is Rook).ToList();
            var queens = chess.Position.Where(kp => kp.Value is Queen).ToList();
            var kings = chess.Position.Where(kp => kp.Value is King).ToList();

            Assert.Equal(16, pawns.Count);
            Assert.All(pawns, kp =>
                {
                    Assert.Equal(kp.Value.Color ? Ranks.two : Ranks.seven, kp.Key.Rank);
                });

            Assert.Equal(4, knights.Count);
            Assert.All(knights, kp =>
                {
                    Assert.Equal(kp.Value.Color ? Ranks.one : Ranks.eight, kp.Key.Rank);
                    Assert.True(kp.Key.File == Files.b || kp.Key.File == Files.g);
                });

            Assert.Equal(4, bishops.Count);
            Assert.All(bishops, kp =>
                {
                    Assert.Equal(kp.Value.Color ? Ranks.one : Ranks.eight, kp.Key.Rank);
                    Assert.True(kp.Key.File == Files.c || kp.Key.File == Files.f);
                });

            Assert.Equal(4, rooks.Count);
            Assert.All(rooks, kp =>
                {
                    Assert.Equal(kp.Value.Color ? Ranks.one : Ranks.eight, kp.Key.Rank);
                    Assert.True(kp.Key.File == Files.a || kp.Key.File == Files.h);
                });

            Assert.Equal(2, queens.Count);
            Assert.All(queens, kp =>
                {
                    Assert.Equal(kp.Value.Color ? Ranks.one : Ranks.eight, kp.Key.Rank);
                    Assert.True(kp.Key.File == Files.d);
                });

            Assert.Equal(2, kings.Count);
            Assert.All(kings, kp =>
                {
                    Assert.Equal(kp.Value.Color ? Ranks.one : Ranks.eight, kp.Key.Rank);
                    Assert.True(kp.Key.File == Files.e);
                });
        }
        
        [Fact]
        public void TestProcessMove()
        {
            IChess chess = new Classical();

            var move = new Move(
                new Square(Files.e, Ranks.two),
                new Square(Files.e, Ranks.four),
                MoveType.Rush);

            Assert.True(chess.Process(move, out IPiece p));

            Assert.Equal(30, chess.AvailableMoves(true).Count);
        }

        [Fact]
        public void TestAClassicalGame()
        {
            IChess chess = new Classical();

            IPiece piece;

            Assert.All(GameOfChessData, tuple =>
            {
                Assert.True(chess.Process(tuple.Item1, out piece));
                if (tuple.Item3 == null)
                    Assert.Null(piece);
                else
                {
                    Assert.Equal(tuple.Item3.GetType(), piece.GetType());
                    Assert.Equal(tuple.Item3.Color, piece.Color);
                }
                Assert.Equal(tuple.Item2,
                chess.AvailableMoves(chess.MoveEntries.Last().Position[tuple.Item1.FromSquare].Color).Count);
                Assert.Equal(tuple.Item4, chess.Position.Count);
            });
        }

        //TODO: Finish testing classical chess.

        private IReadOnlyList<Tuple<Move, int, IPiece, int>> GameOfChessData 
            => new List<Tuple<Move, int, IPiece, int>>()
                {
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.e, Ranks.two), 
                            new Square(Files.e, Ranks.four), MoveType.Rush), 
                        30,
                        null,
                        32),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.d, Ranks.seven), 
                            new Square(Files.d, Ranks.five), MoveType.Rush), 
                        29,
                        null,
                        32),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.e, Ranks.four), 
                            new Square(Files.d, Ranks.five), MoveType.Capture), 
                        30,
                        new Pawn(false),
                        31)
            };

    }
}