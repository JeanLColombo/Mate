using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Pieces;
using Mate.Core.Elements.Rules;
using Mate.Core.Extensions;

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

            Assert.Empty(chess.AvailableMoves(true));
            Assert.True(chess.IsChecked<Classical>(true));
        }

        public static IReadOnlyList<Tuple<Move, int, IPiece, int>> GameOfChessData 
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
                        31),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.d, Ranks.eight), 
                            new Square(Files.d, Ranks.five), MoveType.Capture), 
                        47,
                        new Pawn(true),
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.f, Ranks.one), 
                            new Square(Files.b, Ranks.five), MoveType.Normal), 
                        34,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.eight), 
                            new Square(Files.d, Ranks.seven), MoveType.Normal), 
                        38,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.d, Ranks.one), 
                            new Square(Files.g, Ranks.four), MoveType.Normal), 
                        48,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.a, Ranks.seven), 
                            new Square(Files.a, Ranks.five), MoveType.Rush), 
                        39,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.b, Ranks.one), 
                            new Square(Files.c, Ranks.three), MoveType.Normal), 
                        51,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.a, Ranks.five), 
                            new Square(Files.a, Ranks.four), MoveType.Normal), 
                        40,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.g, Ranks.one), 
                            new Square(Files.e, Ranks.two), MoveType.Normal), 
                        48,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.a, Ranks.eight), 
                            new Square(Files.a, Ranks.five), MoveType.Normal), 
                        41,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.e, Ranks.one), 
                            new Square(Files.g, Ranks.one), MoveType.Castle), 
                        45,
                        null,
                        30),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.d, Ranks.five), 
                            new Square(Files.b, Ranks.five), MoveType.Capture), 
                        40,
                        new Bishop(true),
                        29),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.b, Ranks.two), 
                            new Square(Files.b, Ranks.four), MoveType.Rush), 
                        39,
                        null,
                        29),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.a, Ranks.four), 
                            new Square(Files.b, Ranks.three), MoveType.Passant), 
                        44,
                        new Pawn(true),
                        28),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.three), 
                            new Square(Files.b, Ranks.five), MoveType.Capture), 
                        46,
                        new Queen(false),
                        27),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.b, Ranks.three), 
                            new Square(Files.b, Ranks.two), MoveType.Normal), 
                        41,
                        null,
                        27),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.g, Ranks.four), 
                            new Square(Files.d, Ranks.seven), MoveType.Capture), 
                        41,
                        new Bishop(false),
                        26),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.e, Ranks.eight), 
                            new Square(Files.d, Ranks.seven), MoveType.Capture), 
                        39,
                        new Queen(true),
                        25),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.two), 
                            new Square(Files.c, Ranks.four), MoveType.Rush), 
                        26,
                        null,
                        25),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.b, Ranks.two), 
                            new Square(Files.c, Ranks.one), MoveType.PromoteToRook), 
                        35,
                        new Bishop(true),
                        24),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.four), 
                            new Square(Files.c, Ranks.five), MoveType.Normal), 
                        28,
                        null,
                        24),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.a, Ranks.five), 
                            new Square(Files.a, Ranks.two), MoveType.Capture), 
                        38,
                        new Pawn(true),
                        23),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.five), 
                            new Square(Files.c, Ranks.six), MoveType.Normal), 
                        28,
                        null, 
                        23),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.d, Ranks.seven), 
                            new Square(Files.e, Ranks.eight), MoveType.Normal), 
                        36,
                        null, 
                        23),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.six), 
                            new Square(Files.b, Ranks.seven), MoveType.Capture), 
                        26,
                        new Pawn(false), 
                        22),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.a, Ranks.two), 
                            new Square(Files.a, Ranks.one), MoveType.Capture), 
                        34,
                        new Rook(true),
                        21),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.d, Ranks.two),
                            new Square(Files.d, Ranks.three), MoveType.Normal),
                        22,
                        null,
                        21),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.b, Ranks.eight), 
                            new Square(Files.c, Ranks.six), MoveType.Normal), 
                        35,
                        null,
                        21),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.b, Ranks.seven), 
                            new Square(Files.b, Ranks.eight), MoveType.PromoteToKnight), 
                        25,
                        null,
                        21),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.six), 
                            new Square(Files.b, Ranks.eight), MoveType.Capture), 
                        34,
                        new Knight(true),
                        20),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.d, Ranks.three), 
                            new Square(Files.d, Ranks.four), MoveType.Normal), 
                        20,
                        null,
                        20),
                    new Tuple<Move, int, IPiece, int>(
                        new Move(
                            new Square(Files.c, Ranks.one), 
                            new Square(Files.f, Ranks.one), MoveType.Capture), 
                        34,
                        new Rook(true),
                        19)
                };
    }
}