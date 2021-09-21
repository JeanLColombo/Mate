using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Core.Abstractions;
using Core.Elements.Pieces;
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
            //TODO: Implement custom chess;
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
                    {new Square(Files.g, Ranks.eight), new Queen(true)},   
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
                    {new Square(Files.g, Ranks.eight), new Queen(true)},   
                    {new Square(Files.h, Ranks.eight), new King(false)},  
                    }, 
                true,
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
                    {new Square(Files.g, Ranks.eight), new King(true)},   
                    {new Square(Files.h, Ranks.eight), new Queen(false)},  
                    }, 
                false,
                true
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
            };
    }
}