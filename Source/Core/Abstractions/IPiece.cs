using System.Collections.Generic;

namespace Core.Abstractions
{
    public interface IPiece
    {
        IReadOnlyCollection<Move> AvailableMoves { get; }
    }
}