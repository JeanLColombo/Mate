using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements.Pieces;
using Core.Elements.Rules;
using Tests.Core.Mocks;

namespace Tests.Core.Elements.Rules
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
            var chess = new Custom(CustomPositionA);

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

            var chess = new Custom(CustomPositionA, banned);

            var whiteMoves = chess.AllMoves(true);
            var blackMoves = chess.AllMoves(false);

            Assert.Equal(whiteMoveCount, whiteMoves.Count());
            Assert.Equal(blackMoveCount, blackMoves.Count());

        }

        [Fact]
        public void TestAllMovesWithEnPassant()
        {
            var customBoard = new Dictionary<Square, IPiece>() {
                {new Square(Files.a, Ranks.five), new Pawn(true)},
                {new Square(Files.b, Ranks.seven), new Pawn(false)}
            };

            var withPassant = new Custom(customBoard);
            var bansPassant = new Custom(customBoard, 
                new HashSet<MoveType>() { MoveType.Passant });

            var rushMove = withPassant.AllMoves(false).Where(m => m.Type == MoveType.Rush).Single();

            ((IChess)withPassant).Process(rushMove, out IPiece withPiece);
            ((IChess)bansPassant).Process(rushMove, out IPiece bansPiece);

            var allWithMoves = withPassant.AllMoves(true);
            var allBansMoves = bansPassant.AllMoves(true);

            Assert.Equal(2, allWithMoves.Count());
            Assert.Single(allBansMoves);

            var passantMove = allWithMoves.Where(m => m.Type == MoveType.Passant).Single();

            Assert.True(passantMove.FromSquare.IsSameSquareAs(new Square(Files.a, Ranks.five)));
            Assert.True(passantMove.ToSquare.IsSameRankAs(new Square(Files.b, Ranks.six)));
        }

        [Fact]
        public void TestEnPassantWrongTrigger()
        {
            var customBoard = new Dictionary<Square, IPiece>() {
                {new Square(Files.a, Ranks.five ), new Pawn(true)},
                {new Square(Files.b, Ranks.seven), new Pawn(false)},
                {new Square(Files.h, Ranks.one  ), new King(true)},
                {new Square(Files.h, Ranks.eight), new King(false)},
            };

            var chess = new Custom(customBoard);

            var rushMove = chess.AllMoves(false).Where(m => m.Type == MoveType.Rush).Single();
            var whiteKing = chess.AllMoves(true).Where(m => m.FromSquare.File == Files.h).ToList().First();
            var blackKing = chess.AllMoves(false).Where(m => m.FromSquare.File == Files.h).ToList().First();

            IPiece piece = null;

            // Process a rush move - triggers En Passant
            ((IChess)chess).Process(rushMove, out piece);

            // Process a move with white king - abdicates En Passant
            ((IChess)chess).Process(whiteKing, out piece);

            // Process a move with black king - Rushed pawn on the same square
            // This is a wrong trigger, as En Passant was abdicated
            ((IChess)chess).Process(blackKing, out piece);

            Assert.Empty(chess.AllMoves(true).Where(m => m.Type == MoveType.Passant).ToList());
        }

        [Fact]
        public void TestProcessInvalidMove()
        {
            IChess chess = new Custom(CustomPositionB);
            var move = new Move(
                new Square(Files.a, Ranks.one),
                new Square(Files.b, Ranks.two),
                MoveType.Normal);

            Assert.False(chess.Process(move, out IPiece piece));

            Assert.Null(piece);
            Assert.Empty(chess.MoveEntries);
        }

        [Fact]
        public void TestProcessNormal()
        {
            var fromSquare = new Square(Files.a, Ranks.one);
            var toSquare = new Square(Files.b, Ranks.three);

            IChess chess = new Custom(CustomPositionB);

            var move = new Move(fromSquare, toSquare, MoveType.Normal);

            Assert.True(chess.Process(move, out IPiece piece));

            Assert.Null(piece);
            Assert.Single(chess.MoveEntries);

            Assert.False(chess.Position.ContainsKey(fromSquare));
            Assert.True(chess.Position.ContainsKey(toSquare));

            Assert.True(chess.Position[toSquare] is Knight);
            Assert.True(chess.Position[toSquare].Color);

            Assert.True(chess.MoveEntries.Last().Position.ContainsKey(fromSquare));
            Assert.False(chess.MoveEntries.Last().Position.ContainsKey(toSquare));

            Assert.Equal(move, chess.MoveEntries.Last().Move);
        }

        [Fact]
        public void TestProcessPawnRush()
        {
            var fromSquare = new Square(Files.h, Ranks.seven);
            var toSquare = new Square(Files.h, Ranks.five);

            IChess chess = new Custom(CustomPositionB);

            var move = new Move(fromSquare, toSquare, MoveType.Rush);

            Assert.True(chess.Process(move, out IPiece piece)); 

            Assert.Null(piece);

            Assert.False(chess.Position[toSquare].Color);
            Assert.True(chess.Position[toSquare] is Pawn);
        }

        [Fact]
        public void TestProcessCapture()
        {
            var fromSquare = new Square(Files.a, Ranks.one);
            var toSquare = new Square(Files.c, Ranks.two);

            IChess chess = new Custom(CustomPositionB);

            var move = new Move(fromSquare, toSquare, MoveType.Capture);

            Assert.True(chess.Process(move, out IPiece piece));

            Assert.NotNull(piece);
            Assert.True(piece is MockedPiece);
            Assert.False(piece.Color);
            
            Assert.True(chess.Position[toSquare] is Knight);
            Assert.True(chess.Position[toSquare].Color);
            Assert.NotSame(piece, chess.Position[toSquare]);

            Assert.Empty(chess.Position.Values.Where(p => p == piece).ToList());
        }

        [Fact]
        public void TestProcessEnPassant()
        {
            var fromSquare = new Square(Files.g, Ranks.five);
            var toSquare = new Square(Files.h, Ranks.six);

            IChess chess = new Custom(CustomPositionB);

            var rushed = chess.AvailableMoves(false).Where(m => m.Type == MoveType.Rush).Single();
            var passant = new Move(fromSquare, toSquare, MoveType.Passant);

            IPiece piece = null;

            // Triggers En Passant
            chess.Process(rushed, out piece);

            // Executes it
            Assert.True(chess.Process(passant, out piece));

            Assert.NotNull(piece);
            Assert.True(piece is Pawn);
            Assert.False(piece.Color);

            Assert.True(chess.Position[toSquare] is Pawn);
            Assert.True(chess.Position[toSquare].Color);
            Assert.NotSame(piece, chess.Position[toSquare]);

            Assert.Empty(chess.Position.Values.Where(p => p == piece).ToList());
            Assert.DoesNotContain(new Square(Files.h, Ranks.five), chess.Position.Keys);
        }

        private IReadOnlyDictionary<Square, IPiece> CustomPositionA =>
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

        private IReadOnlyDictionary<Square, IPiece> CustomPositionB => 
            new Dictionary<Square, IPiece>() {
                {new Square(Files.a, Ranks.one  ), new Knight(true)         },
                {new Square(Files.h, Ranks.seven), new Pawn(false)          },
                {new Square(Files.c, Ranks.two  ), new MockedPiece(false)   },
                {new Square(Files.g, Ranks.five ), new Pawn(true)           }
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