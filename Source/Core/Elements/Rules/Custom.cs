using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Elements.Pieces;
using Core.Extensions;
using Core.Extensions.SpecializedMoves;

namespace Core.Elements.Rules
{
    /// <summary>
    /// Defines a fully customizable game of chess. Special moves can be enabled and / or disabled and 
    /// pieces can be set to any given configuration. 
    /// 
    /// Configuration are passed through via constructor.
    /// </summary>
    public class Custom : Chess
    {

        /// <summary>
        /// List of banned moves. Instanced on construction. <see cref="Core.Abstractions.MoveType"/>'s on this list are not allowed.  
        /// </summary>
        public readonly IEnumerable<MoveType> BannedMoves;

        /// <summary>
        /// Instantiate a new <see cref="Custom"/> game of chess with the give <see paramrefname="position"/> on the board. 
        /// </summary>
        /// <param name="position">A read-only dictionary of pieces.</param>
        public Custom(IReadOnlyDictionary<Square, IPiece> position) : this(
            position, 
            new HashSet<MoveType>(Enumerable.Empty<MoveType>())) {}

        /// <summary>
        /// Instantiate a new <see cref="Custom"/> game of chess with the give <see paramrefname="position"/> on the board,
        /// as well as a given list of banned <see paramrefname="bannedMoves"/> entries.
        /// </summary>
        /// <param name="position">A read-only dictionary of pieces.</param>
        /// <param name="bannedMoves">A list of banned <see cref="Core.Abstractions.MoveType"/> entries.</param>
        public Custom(
            IReadOnlyDictionary<Square, IPiece> position, 
            HashSet<MoveType> bannedMoves) 
            : base(position)
        {
            BannedMoves = bannedMoves;
        }

        /// <summary>
        /// All possible moves for player with pieces of the given <paramref name="color"/>, whether or not their are
        /// legal. 
        /// </summary>
        /// <param name="color"><see langword="true"/> for white, <see langword="false for black"/> for black.</param>
        /// <returns>A read-only collection of <see cref="Move"/> instances.</returns>
        public override IReadOnlyCollection<Move> AllMoves(bool color)
        {
            // Select pieces by color
            var pieces = Position.Values.Where(p => p.Color == color).ToList();

            // Piece's moves
            var moves = pieces.SelectMany(p => p.AvailableMoves(Position)).ToList();

            // Pawn's special moves
            var pawnMoves = pieces
                .Where(p => p is Pawn)
                .Where(p => !p.HasMoved(Position, MoveEntries))
                .SelectMany(p => 
                    p.PawnFirstMove(Position).Union(
                    p.EnPassant(Position, MoveEntries)))
                .ToList();

            // King's special moves
            var kingMoves = pieces
                .Where(p => p is King)
                .SelectMany(p => 
                    p.Castles(Position, MoveEntries))
            .ToList();

            // Append and query banned moves
            return moves
                .Union(pawnMoves)
                .Union(kingMoves)
                .Where(m => !BannedMoves.Contains(m.Type))
                .ToList();
        }

        /// <summary>
        /// Currently available moves for player with pieces of the given <see paramrefname="color"/>, based on the
        /// list of banned moves.
        /// </summary>
        /// <param name="color"><see langword="true"/> for white, <see langword="false for black"/> for black.</param>
        /// <returns>A read-only collection of <see cref="Move"/> instances.</returns>
        /// <exception cref="System.NotImplementedException">This method is not yet implemented.</exception>
        public override IReadOnlyCollection<Move> AvailableMoves(bool color)
        {
            // TODO: Implement this method - this is just a simple overload.
            return AllMoves(color);
        }

        /// <summary>
        /// Process the given <paramref name="move"/>.
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <param name="piece">A reference to a possibly captured piece.</param>
        /// <returns><see langword="true"/> if the move was processed correctly. Otherwise, 
        /// returns <see langword="false"/>.</returns>
        public override bool Process(Move move, out IPiece piece)
        {
            piece = null;
            
            switch (move.Type)
            {
                case MoveType.Capture:
                    // Sets reference to captured piece
                    piece = Position[move.ToSquare];
                    ProcessCapture(move);
                    break;
                case MoveType.Passant:
                    ProcessEnPassant(move, out piece);
                    break;
                case MoveType.Castle:
                    ProcessCastle(move);
                    break;
                case MoveType.PromoteToKnight:
                case MoveType.PromoteToBishop:
                case MoveType.PromoteToRook:
                case MoveType.PromoteToQueen:
                    // Process all promotions simultaneously
                    ProcessPromotion(move, out piece);
                    break;
                default:
                    // Proccess Normal and Rush moves
                    ProcessNormal(move);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Process a <see cref="MoveType.Normal"/> <paramref name="move"/>. 
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        private void ProcessNormal(Move move)
        {
            // Removes piece from one square...
            this.RemovePiece(move.FromSquare, out IPiece piece);

            // ... to another square.
            this.AddPiece(move.ToSquare, piece);
        }

        /// <summary>
        /// Process a <see cref="MoveType.Capture"/> <paramref name="move"/>. 
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        private void ProcessCapture(Move move)
        {
            // Clears destination square... 
            this.Clear(move.ToSquare);

            // ... then process it like a normal move
            ProcessNormal(move);
        }

        /// <summary>
        /// Process a <see cref="MoveType.Passant"/> <paramref name="move"/>.
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        /// <param name="rushedPawn">The captured <see cref="Pawn"/>.</param>
        private void ProcessEnPassant(Move move, out IPiece rushedPawn)
        {
            // Determines the rushedPawn square...
            var rushedToSquare = new Square(move.ToSquare.File, move.FromSquare.Rank);

            // ... and removes it from the board 
            // into its reference
            this.RemovePiece(rushedToSquare, out rushedPawn);

            // Now, process the remaining piece like normal
            ProcessNormal(move);
        }

        /// <summary>
        /// Process a <see cref="MoveType.Castle"/> <paramref name="move"/>.
        /// </summary>
        /// <param name="move">A given <see cref="Move"/>.</param>
        private void ProcessCastle(Move move)
        {
            // Define the type of castle 
            var kingSideCastle = move.ToSquare.File == Files.g;

            // Determines the rook squares
            var rookFromSquare = new Square(
                kingSideCastle ? Files.h : Files.a,
                move.FromSquare.Rank
            );
            var rookToSquare = new Square(
                kingSideCastle ? Files.f : Files.d,
                move.ToSquare.Rank
            );

            // Reposition the rook
            ProcessNormal(new Move(rookFromSquare, rookToSquare, MoveType.Normal));

            // Castle the king
            ProcessNormal(move);
        }

        /// <summary>
        /// Process any promotion <paramref name="move"/>.
        /// </summary>
        /// <param name="move">A given <see cref="Move"/> whose <see cref="Move.Type"/>
        /// is either <see cref="MoveType.PromoteToKnight"/>, <see cref="MoveType.PromoteToBishop"/>,
        /// <see cref="MoveType.PromoteToRook"/> or <see cref="MoveType.PromoteToQueen"/>.</param>
        /// <param name="piece">Returns a reference to the captured <see cref="IPiece"/>.</param>
        private void ProcessPromotion(Move move, out IPiece piece)
        {
            // Checks if promotion yields a capture... 
            if (Position.TryGetValue(move.ToSquare, out piece))
            {
                // ... and clears destination square
                this.Clear(move.ToSquare);
            }

            // Defines pawn new form
            bool color = Position[move.FromSquare].Color;
            IPiece promotedPiece = null;

            switch (move.Type)
            {
                case MoveType.PromoteToKnight:
                    promotedPiece = new Knight(color);
                    break;
                case MoveType.PromoteToBishop:
                    promotedPiece = new Bishop(color);
                    break;
                case MoveType.PromoteToRook:
                    promotedPiece = new Rook(color);
                    break;
                case MoveType.PromoteToQueen:
                    promotedPiece = new Queen(color);
                    break;
            }


            // Erases pawn from existence...
            this.Clear(move.FromSquare);

            // ... and promotes it to new form
            this.AddPiece(move.ToSquare, promotedPiece);
        }

    }
}