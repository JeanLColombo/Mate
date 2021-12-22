using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;

namespace Tests.Core.Mocks
{
    public class MockedChess : Chess
    {
        /// <summary>
        /// Mock for parameterless <see cref="Chess"/> constructor 
        /// </summary>
        /// <returns></returns>
        public MockedChess() : base() {}

        /// <summary>
        /// Mock for <see cref="Chess"/> constructor 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public MockedChess(IReadOnlyDictionary<Square,IPiece> position) : base(position) {}

        /// <summary>
        /// Mock for <see cref="Chess"/> constructor 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="moveEntries"></param>
        public MockedChess(IReadOnlyDictionary<Square, IPiece> position, IReadOnlyCollection<MoveEntry> moveEntries) : base(position, moveEntries) {}

        /// <summary>
        /// Returns an empty collection of <see cref="Move"/>s.
        /// </summary>
        /// <param name="color">Player color.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AllMoves(bool color)
            => Enumerable.Empty<Move>().ToArray();

        /// <summary>
        /// Returns an empty collection of <see cref="Move"/>s.
        /// </summary>
        /// <param name="color">Player color.</param>
        /// <returns></returns>
        public override IReadOnlyCollection<Move> AvailableMoves(bool color) 
            => Enumerable.Empty<Move>().ToArray();

        /// <summary>
        /// Returns false, with external reference to null. 
        /// </summary>
        /// <param name="move"></param>
        /// <param name="piece"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override bool Process(Move move, out IPiece piece)
        {
            piece = null;
            return false;
        }
    }
}