namespace Core.Abstractions
{
    /// <summary>
    /// Defines a Move available for a given <see cref="IPiece"/>.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Destination <see cref="Square"/>.
        /// </summary>
        /// <value></value>
        public Square ToSquare {get; private set;}

        /// <summary>
        /// Associated <see cref="MoveType"/>.
        /// </summary>
        /// <value></value>
        public MoveType Type {get; private set;}

        /// <summary>
        /// A move must contain the destination <see cref="Square"/>, 
        /// and the <see cref="MoveType"/>, so that if could be properly managed.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        public Move(Square s, MoveType t)
        {
            ToSquare = s;
            Type = t;
        }
    }
}