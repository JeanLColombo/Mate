namespace Mate.Core.Abstractions
{
    /// <summary>
    /// Abstract implementation of a game of <see cref="Chess"/>.
    /// </summary>
    public abstract class Game : IGame
    {
        /// <summary>
        /// The current move being played in the <see cref="Game"/>.
        /// </summary>
        public int CurrentMove { get; protected set; }

        /// <summary>
        /// The current player to make a move.
        /// </summary>
        /// <value><see langword="true"/> for player with white pieces, 
        /// <see langword="false"/> for player with black pieces.</value>
        public bool CurrentPlayer { get; protected set; }

        /// <summary>
        /// The current <see cref="IChess"/> rules of the game.
        /// </summary>
        public IChess Chess { get; private set; }

        /// <summary>
        /// Process a given <paramref name="move"/>. 
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public abstract bool ProcessMove(Move move);

        /// <summary>
        /// Creates a new <see cref="Game"/> instance. 
        /// </summary>
        /// <param name="currentMove">Sets the <see cref="Game.CurrentMove"/>.</param>
        /// <param name="currentPlayer">Sets the <see cref="Game.CurrentPlayer"/>.</param>
        /// <param name="rules">A given <see cref="IChess"/> instance.</param>
        public Game(int currentMove, bool currentPlayer, IChess rules)
        {
            CurrentMove = currentMove;
            CurrentPlayer = currentPlayer;
            Chess = rules;
        }

        int IGame.CurrentMove => CurrentMove;

        bool IGame.CurrentPlayer => CurrentPlayer;

        IChess IGame.Chess => Chess;

        bool IGame.ProcessMove(Move m) => ProcessMove(m);
    }
}