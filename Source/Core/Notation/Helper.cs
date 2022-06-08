using System;
using System.Collections.Generic;
using System.Linq;
using Mate.Core.Abstractions;


namespace Mate.Core.Notation;
/// <summary>
/// Provide extension helper methods for chess notation. 
/// </summary>
public static class Helper
{
    /// <summary>
    /// Returns a string value representing the given <see cref="Square"/>. 
    /// </summary>
    /// <param name="square">A given <see cref="Square"/> instance.</param>
    /// <returns>A string representing following square notation.</returns>
    public static string SquareToNotation(Square square)
    {
        var list = FileToString();
        return list[square.File] + (int)square.Rank;
    }

    /// <summary>
    /// Maps <see cref="Files"/> instances with their respective string. 
    /// </summary>
    /// <returns>A dictionary of <see cref="Files"/> - <see cref="string"/> tuple.</returns>
    private static IReadOnlyDictionary<Files, string> FileToString() =>
        Enum.GetValues(typeof(Files)).Cast<Files>().ToDictionary(f => f, f => f.ToString());
}