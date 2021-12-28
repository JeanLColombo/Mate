namespace Mate.Core.Abstractions
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

        /// <summary>
        /// <see cref="Equals"/> override, comparing this instance to
        /// a given <paramref name="obj"/>. 
        /// </summary>
        /// <param name="obj">A given <see langword="object"/>.</param>
        /// <returns><see langword="true"/> if both are <see cref="Move"/> instances
        /// with matching properties.</returns>
        public override bool Equals(object obj)
        {
            // For null objects or objects that are not Move instances
            // returns false
            if ((obj is null) || !(obj is Move)) return false;

            // Cast object to Move
            var moveObj = (Move)obj;

            // Property matching rules
            return FromSquare.IsSameSquareAs(moveObj.FromSquare)    &&
                ToSquare.IsSameSquareAs(moveObj.ToSquare)         &&
                Type == moveObj.Type;
        }

        /// <summary>
        /// <see cref="GetHashCode"/> override for <see cref="Move"/>. 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}