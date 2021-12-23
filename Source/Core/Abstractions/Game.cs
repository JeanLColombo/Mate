namespace Core.Abstractions
{
    /// <summary>
    /// Abstract implementation of a game of <see cref="Chess"/>.
    /// </summary>
    public abstract class Game : IGame
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract int CurrentMove { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public abstract bool CurrentPlayer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public abstract IChess Chess { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public abstract bool ProcessMove(Move move);
    }
}