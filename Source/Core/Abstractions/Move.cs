namespace Core.Abstractions
{
    public class Move
    {
        public Square Square {get; private set;}

        public MoveType Type {get; private set;}

        public Move(Square s, MoveType t)
        {
            Square = s;
            Type = t;
        }
    }
}