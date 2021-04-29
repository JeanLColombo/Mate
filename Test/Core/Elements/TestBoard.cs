using System;
using System.Collections.Generic;
using Xunit;
using Core.Elements;
using Core.Abstractions;

namespace Tests.Core.Elements
{
    public class TestBoard
    {
        [Fact]
        public void TestBoardConstructor()
        {
            var b = new Board();
        }

        [Fact]
        public void TestBoardSize()
        {
            var b = new Board();

            Assert.Equal(64, b.Position.Count);
        }

        [Fact]
        public void TestIfBoardIsEmpty()
        {
            var b = new Board();

            foreach (Files f in Enum.GetValues(typeof(Files)))
                foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
                    Assert.Null(b.Position[new Square(f, r)]);
        }

        //TODO: Change from list to dictionary - get elements via their file and ranks.
    }
}