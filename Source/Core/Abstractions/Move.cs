namespace Core.Abstractions
{
    /// <summary>
    /// Defines a Move available for a given <c>IPiece</c>.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Destination <c>Square</c>.
        /// </summary>
        /// <value></value>
        public Square Square {get; private set;}

        /// <summary>
        /// Associated <c>MoveType<c/>.
        /// </summary>
        /// <value></value>
        public MoveType Type {get; private set;}

        /// <summary>
        /// A move must contain the destination <c>Square</c>, and the <c>MoveType</c>, so that if could be properly managed.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        public Move(Square s, MoveType t)
        {
            Square = s;
            Type = t;
        }
    }
}