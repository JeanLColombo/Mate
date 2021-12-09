namespace Core.Abstractions
{

    /// <summary>
    /// Defines all Files within a Chess board.
    /// </summary>
    public enum Files
    {
        /// <summary>
        /// A File.
        /// </summary>
        a = 1,
        /// <summary>
        /// B File 
        /// </summary>
        b = 2,
        /// <summary>
        /// C File
        /// </summary>
        c = 3,
        /// <summary>
        /// D File 
        /// </summary>
        d = 4,
        /// <summary>
        /// E File
        /// </summary>
        e = 5,
        /// <summary>
        /// F File
        /// </summary>
        f = 6,
        /// <summary>
        /// G File
        /// </summary>
        g = 7,
        /// <summary>
        /// H File
        /// </summary>
        h = 8
    }


    /// <summary>
    /// Defines all Ranks within a Chess board.
    /// </summary>
    public enum Ranks
    {
        /// <summary>
        /// First Rank
        /// </summary>
        one = 1,
        /// <summary>
        /// Second Rank
        /// </summary>
        two = 2,
        /// <summary>
        /// Third Rank
        /// </summary>
        three = 3,
        /// <summary>
        /// Forth Rank
        /// </summary>
        four = 4,
        /// <summary>
        /// Fifth Rank
        /// </summary>
        five = 5,
        /// <summary>
        /// Sixth Rank
        /// </summary>
        six = 6,
        /// <summary>
        /// Seventh Rank
        /// </summary>
        seven = 7,
        /// <summary>
        /// Eighth Rank
        /// </summary>
        eight = 8
    }


    /// <summary>
    /// Defines all types of moves in a Chess game.
    /// </summary>
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

    /// <summary>
    /// Defines all possible orientations of movements through the board.
    /// </summary>
    public enum Through{
        Files = 1,
        Ranks = 2,
        MainDiagonal = 3,
        OppositeDiagonal = 4
    }
}