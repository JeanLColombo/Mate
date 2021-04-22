using System;
using System.Collections.Generic;
using Core.Abstractions;

namespace Core.Elements
{
    public class Board
    {
        public IReadOnlyCollection<Square> Squares { get => _squares; }

        private List<Square> _squares {get; set;} = new  List<Square>();

        public Board() => BuildBoard();

        private void BuildBoard()
        {
            foreach (Files f in Enum.GetValues(typeof(Files)))
                foreach (Ranks r in Enum.GetValues(typeof(Ranks)))
                    _squares.Add(new Square(f, r));
        }
    }
}