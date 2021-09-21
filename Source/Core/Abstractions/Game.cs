namespace Core.Abstractions
{
    /// <summary>
    /// Abstract implementation of a game of <see cref="Chess"/>.
    /// </summary>
    public abstract class Game : IGame
    {
        public abstract int CurrentMove { get; set; }
        public abstract bool CurrentPlayer { get; set; }
        public abstract IChess Chess { get; }

        public abstract bool ProcessMove(Move move);
    }
}