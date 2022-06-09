using System;
using System.Collections.Generic;
using System.Linq;
using Mate.Core.Abstractions;
using Mate.Core.Elements.Pieces;


namespace Mate.Core.Notation;
/// <summary>
/// Provide extension helper methods for chess notation. 
/// </summary>
public static class Conversion
{
    /// <summary>
    /// Returns a string value representing the given <see cref="Square"/>. 
    /// </summary>
    /// <param name="square">A given <see cref="Square"/> instance.</param>
    /// <returns>A string representing the square notation.</returns>
    public static string SquareToNotation(Square square) =>
        FileToString()[square.File] + (int)square.Rank;


    /// <summary>
    /// Returns the chess notation for a given <paramref name="piece"/>.
    /// </summary>
    /// <param name="piece">A given chess <see cref="IPiece"/>.</param>
    /// <returns>A string representing the piece chess notation.</returns>
    public static string PieceToNotation(IPiece piece)
    {
        switch (piece)
        {
            case Bishop bishop:
                return "B";
            case King king:
                return "K";
            case Knight knight:
                return "N";
            case Queen queen:
                return "Q";
            case Rook rook:
                return "R";
            default:
                return "";
        }
    }

    /// <summary>
    /// Generates the chess notation for the given <paramref name="move"/>.
    /// </summary>
    /// <param name="move">A given chess <see cref="Move"/>.</param>
    /// <returns>A string representing the actual chess notation</returns>
    public static string MoveToNotation(Move move)
    {
        // Control variables
        var capture = "";
        var promotion = "";

        // Set capture and promotion values based on move type and occupation
        switch (move.Type)
        {
            case MoveType.Castle:
                if (move.ToSquare.File == Files.g) return "0-0";
                else return "0-0-0";
            case MoveType.Capture:
                capture = "x";
                break;
            case MoveType.Passant:
                capture =  "x";
                break;
            case MoveType.PromoteToBishop:
                promotion = "=B";
                capture = move.FromSquare.File != move.ToSquare.File ? "x" : "";
                break;
            case MoveType.PromoteToKnight:
                promotion = "=N";
                capture = move.FromSquare.File != move.ToSquare.File ? "x" : "";
                break;
            case MoveType.PromoteToQueen:
                promotion = "=Q";
                capture = move.FromSquare.File != move.ToSquare.File ? "x" : "";
                break;
            case MoveType.PromoteToRook:
                promotion = "=R";
                capture = move.FromSquare.File != move.ToSquare.File ? "x" : "";
                break;
            default:
                break;
        }

        return SquareToNotation(move.FromSquare) + capture + SquareToNotation(move.ToSquare) + promotion;
    }

    /// <summary>
    /// Maps <see cref="Files"/> instances with their respective string. 
    /// </summary>
    /// <returns>A dictionary of <see cref="Files"/> - <see cref="string"/> tuple.</returns>
    private static IReadOnlyDictionary<Files, string> FileToString() =>
        Enum.GetValues(typeof(Files)).Cast<Files>().ToDictionary(f => f, f => f.ToString());
}