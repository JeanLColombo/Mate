namespace Mate.Core.Abstractions
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
        /// <summary>
        /// When a <see cref="Piece"/> moves to an unoccupied <see cref="Square"/>. 
        /// </summary>
        Normal = 0,
        /// <summary>
        /// When a <see cref="Piece"/> moves to an <see cref="Square"/> occupied another <see cref="Piece"/> of opposite 
        /// <see cref="Piece.Color"/>. 
        /// </summary>
        Capture = 1,
        /// <summary>
        /// A <see cref="Core.Elements.Pieces.Pawn"/> move executed under special circumstances. 
        /// </summary>
        Passant = 2,
        /// <summary>
        /// A <see cref="Core.Elements.Pieces.Pawn"/> rush move, available if the pawn has not yet
        /// moved. 
        /// </summary>
        Rush = 3,
        /// <summary>
        /// A <see cref="Core.Elements.Pieces.King"/> move hides behind a 
        /// <see cref="Core.Elements.Pieces.Rook"/> of same <see cref="Piece.Color"/>. 
        /// </summary>
        Castle = 4,
        /// <summary>
        /// A move where a <see cref="Core.Elements.Pieces.Pawn"/> promotes to a <see cref="Core.Elements.Pieces.Knight"/>. 
        /// </summary>
        PromoteToKnight = 5,
        /// <summary>
        /// A move where a <see cref="Core.Elements.Pieces.Pawn"/> promotes to a <see cref="Core.Elements.Pieces.Bishop"/>. 
        /// </summary>
        PromoteToBishop = 6,
        /// <summary>
        /// A move where a <see cref="Core.Elements.Pieces.Pawn"/> promotes to a <see cref="Core.Elements.Pieces.Rook"/>. 
        /// </summary>
        PromoteToRook = 7,
        /// <summary>
        /// A move where a <see cref="Core.Elements.Pieces.Pawn"/> promotes to a <see cref="Core.Elements.Pieces.Queen"/>. 
        /// </summary>
        PromoteToQueen = 8
    }

    /// <summary>
    /// Defines all possible orientations of movements through the board.
    /// </summary>
    public enum Through{
        /// <summary>
        /// Along the <see cref="Files"/>. 
        /// </summary>
        Files = 1,
        /// <summary>
        /// Along the <see cref="Ranks"/>. 
        /// </summary>
        Ranks = 2,
        /// <summary>
        /// Advancing through <see cref="Files"/> and <see cref="Ranks"/> simultaneously. 
        /// </summary>
        MainDiagonal = 3,
        /// <summary>
        /// Retreating through <see cref="Files"/> and advancing through <see cref="Ranks"/> simultaneously. 
        /// </summary>
        OppositeDiagonal = 4
    }

    /// <summary>
    /// Defines all possible outcomes of a <see cref="IGame"/> of <see cref="IChess"/>. 
    /// </summary>
    public enum Outcome{
        /// <summary>
        /// The game is on. The <see cref="Outcome"/> is undecided.
        /// </summary>
        Game = 0,
        /// <summary>
        /// The current player is under check. The <see cref="Outcome"/> is undecided. 
        /// </summary>
        Checked = 1,
        /// <summary>
        /// The game has stalemated. It is a draw. See the current <see cref="IGame"/> 
        /// implementation for more information. 
        /// The <see cref="IGame"/> is over.
        /// </summary>
        Stalemate = 2,
        /// <summary>
        /// The <see cref="IGame.CurrentPlayer"/> is checkmated. 
        /// The <see cref="IGame"/> is over.
        /// </summary>
        Checkmate = 3
    }
}