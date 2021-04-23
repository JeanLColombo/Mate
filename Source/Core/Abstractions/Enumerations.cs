namespace Core.Abstractions
{
    public enum Files
    {
        a = 1,
        b = 2,
        c = 3,
        d = 4,
        e = 5,
        f = 6,
        g = 7,
        h = 8
    }

    public enum Ranks
    {
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eigth = 8
    }

    public enum MoveType{
        Normal = 1,
        Capture = 2,
        Passant = 3,
        Castle = 4,
        PromoteToKnight = 5,
        PromotToBishop = 6,
        PromoteToRook = 7,
        PromoteToQueen = 8
    }
}