namespace Core.Abstractions
{
    /// <summary>
    /// Defines a Move available for a given <see cref="IPiece"/>.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Origin <see cref="Square"/>.
        /// </summary>
        /// <value></value>
        public Square FromSquare {get;}

        /// <summary>
        /// Destination <see cref="Square"/>.
        /// </summary>
        /// <value></value>
        public Square ToSquare {get;}

        /// <summary>
        /// Associated <see cref="MoveType"/>.
        /// </summary>
        /// <value></value>
        public MoveType Type {get;}
  
        /// <summary>
        /// A move must contain the <paramref name="origin"/> of a <see cref="Piece"/>, 
        /// the destination <paramref name="destination"/>, and the associated
        /// <see cref="MoveType"/>.
        /// </summary>
        /// <param name="origin"><see cref="Piece"/> original <see cref="Square"/>.</param>
        /// <param name="destination">The new <see cref="Square"/></param>
        /// <param name="type">The <see cref="MoveType"/>, so that it can be properly
        /// managed.</param>
        public Move(Square origin, Square destination, MoveType type)
        {
            FromSquare = origin;
            ToSquare = destination;
            Type = type;
        }
    }
}